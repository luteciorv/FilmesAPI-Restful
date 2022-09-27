using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
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
