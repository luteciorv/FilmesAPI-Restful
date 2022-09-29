using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsuariosAPI.Models
{
    public class MensagemEmail
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public MensagemEmail(IEnumerable<string> destinatario, string assunto, int usuarioID, string codigoAtivacao)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(D => new MailboxAddress(D)));
            Assunto = assunto;
            Conteudo = $"http://localhost:6000/Ativar?UsuarioID={usuarioID}&CodigoAtivacao={codigoAtivacao}";
        }
    }
}
