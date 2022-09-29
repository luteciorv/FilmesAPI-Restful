using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using UsuariosAPI.Data;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;        

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioID, string codigoAtivacao)
        {
            MensagemEmail mensagem = new(destinatario, assunto, usuarioID, codigoAtivacao);
            var mensagemEmail = CriarCorpoEmail(mensagem);

            using var clienteSMTP = new SmtpClient();
            try
            {
                clienteSMTP.Connect(
                    _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    _configuration.GetValue<int>("EmailSettings:Port"), true);
                
                clienteSMTP.AuthenticationMechanisms.Remove("XOUATH2");
                
                clienteSMTP.Authenticate(
                    _configuration.GetValue<string>("EmailSettings:From"),
                    _configuration.GetValue<string>("EmailSettings:Password"));
                
                clienteSMTP.Send(mensagemEmail);
            }
            catch (Exception exc)
            {
                throw new Exception($"Erro ao enviar e-mail. Exceção: {exc.Message}");
            }
            finally
            {
                clienteSMTP.Disconnect(true);
                clienteSMTP.Dispose();
            }
        }

        private MimeMessage CriarCorpoEmail(MensagemEmail mensagem)
        {
            var mensagemEmail = new MimeMessage();
            mensagemEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemEmail;
        }
    }
}
