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

                Token token = _tokenService.CriarToken(identityUsuario);
                return Result.Ok().WithSuccess(token.Valor);
            }

            return Result.Fail("Não foi possível Logar com o usuário e senha informados.");
        }
    }
}
