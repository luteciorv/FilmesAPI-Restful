using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Web;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly EmailService _emailService;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }


        public Result CriarUsuario(CriarUsuarioDTO criarDTO)
        {
            var usuario = _mapper.Map<Usuario>(criarDTO);
            var usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, criarDTO.Senha).Result;

            var resultadoCriarCargo = _roleManager.CreateAsync(new IdentityRole<int>("Admin")).Result;
            var resultadoAssociarCargo = _userManager.AddToRoleAsync(usuarioIdentity, "Admin").Result;

            if(resultadoIdentity.Succeeded)
            {
                var codigoAtivacao = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCodigoAtivacao = HttpUtility.UrlEncode(codigoAtivacao);
                
                _emailService.EnviarEmail(new[] {usuarioIdentity.Email}, "Link de ativação do e-mail", usuarioIdentity.Id, encodedCodigoAtivacao);
                return Result.Ok().WithSuccess(codigoAtivacao); 
            }

            return Result.Fail("Não foi possível cadastrar um novo usuário.");
        }


        public Result AtivarContaUsuario(AtivarContaRequest requisicao)
        {
            var identityUsuario = _userManager.Users.FirstOrDefault(U => U.Id == requisicao.UsuarioID);
            var identityResultado = _userManager.ConfirmEmailAsync(identityUsuario, requisicao.CodigoAtivacao).Result;

            if(identityResultado.Succeeded)
            { return Result.Ok(); }

            return Result.Fail("Falha ao ativar a conta do usuário pelo e-mail.");
        }
    }
}