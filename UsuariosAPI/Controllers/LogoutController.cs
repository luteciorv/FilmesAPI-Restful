using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase  
    {
        private readonly LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario()
        {
            Result resultado = _logoutService.DeslogarUsuario();

            if(resultado == null)
            { return Unauthorized(resultado.Errors); }

            return Ok(resultado.Successes);
        }
    }
}