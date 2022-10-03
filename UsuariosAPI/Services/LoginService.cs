using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

      
        public Result LogarUsuario(LoginRequest requisicao)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(requisicao.Usuario, requisicao.Senha, false, false);

            if(resultadoIdentity.Result.Succeeded)
            {
                var identityUsuario = _signInManager
                                        .UserManager
                                        .Users
                                        .FirstOrDefault(U => U.NormalizedUserName == requisicao.Usuario.ToUpper());

                string cargo = _signInManager.UserManager.GetRolesAsync(identityUsuario).Result.FirstOrDefault();
                Token token = _tokenService.CriarToken(identityUsuario, cargo);
                
                return Result.Ok().WithSuccess(token.Valor);
            }

            return Result.Fail("Não foi possível Logar com o usuário e senha informados.");
        }


        public Result SolicitarRedefinicaoSenhaUsuario(SolicitarRedefinicaoRequest requisicao)
        {
            IdentityUser<int> usuarioIdentity = RecuperarUsuarioPeloEmail(requisicao.Email);

            if (usuarioIdentity == null)
            {
                return Result.Fail("Não foi possível solicitar a redefinição da senha");
            }

            string codigoRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(usuarioIdentity).Result;
            return Result.Ok().WithSuccess(codigoRecuperacao);
        }

        public Result RedefinirSenhaUsuario(RedefinirRequest requisicao)
        {
            IdentityUser<int> usuarioIdentity = RecuperarUsuarioPeloEmail(requisicao.Email);

            if (usuarioIdentity == null)
            {
                return Result.Fail("Usuário não encontrado");
            }

            IdentityResult resultadoIdentity = _signInManager
                                                .UserManager
                                                .ResetPasswordAsync(usuarioIdentity, requisicao.Token, requisicao.NovaSenha)
                                                .Result;

            if (!resultadoIdentity.Succeeded)
            {
                return Result.Fail("Não foi possível redefinir a senha.");
            }

            return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
        }


        private IdentityUser<int> RecuperarUsuarioPeloEmail(string email)
        {
            return _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(U => U.Email == email.ToUpper());
        }
    }
}
