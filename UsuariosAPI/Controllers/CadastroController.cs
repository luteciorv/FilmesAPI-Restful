using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTO;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CriarUsuarioDTO criarDTO)
        {
            var resultado = _cadastroService.CriarUsuario(criarDTO);

            if(resultado.IsFailed)
            { return StatusCode(500); }

            return Ok(resultado.Successes);
        }

        [HttpPost("/Ativar")]
        public IActionResult AtivarContaUsuario(AtivarContaRequest requisicao)
        {
            Result resultado = _cadastroService.AtivarContaUsuario(requisicao);
            if(resultado.IsFailed)
            { return StatusCode(500); }

            return Ok(resultado.Successes);
        }
    }
}
