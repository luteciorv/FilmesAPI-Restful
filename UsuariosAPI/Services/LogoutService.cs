using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private readonly SignInManager<IdentityUserCustomizado> _signInManager;

        public LogoutService(SignInManager<IdentityUserCustomizado> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogarUsuario()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();

            if(resultadoIdentity.IsCompletedSuccessfully)
            { return Result.Ok(); }

            return Result.Fail("Não foi possível deslogar o usuário");
        }
    }
}
