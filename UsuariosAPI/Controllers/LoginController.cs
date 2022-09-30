using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest requisicao)
        {
            Result resultado = _loginService.LogarUsuario(requisicao);

            if(resultado.IsFailed)
            { return Unauthorized(resultado.Errors); }

            return Ok(resultado.Successes);
        }


        [HttpPost("/SolicitarRedefinicaoSenha")]
        public IActionResult SolicitarRedefinicaoSenhaUsuario(SolicitarRedefinicaoRequest requisicao)
        {
            Result resultado = _loginService.SolicitarRedefinicaoSenhaUsuario(requisicao);

            if(resultado.IsFailed)
            { return Unauthorized(resultado.Errors); }

            return Ok(resultado.Successes);
        }

        [HttpPost("/RedefinirSenha")]
        public IActionResult RedefinirSenhaUsuario(RedefinirRequest requisicao)
        {
            Result resultado = _loginService.RedefinirSenhaUsuario(requisicao);

            if (resultado.IsFailed)
            { return Unauthorized(resultado.Errors); }

            return Ok(resultado.Successes);
        }
    }
}
