using FilmesAPI.Data.DTOS;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;   
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CriarSessaoDTO criarSessaoDTO)
        {
            var lerSessaoDTO = _sessaoService.AdicionarSessao(criarSessaoDTO);

            return CreatedAtAction(nameof(RecuperarSessaoPeloID), new { lerSessaoDTO.ID }, lerSessaoDTO);
        }


        [HttpGet]
        public List<LerSessaoDTO> RecuperarSessoes()
        {
            return _sessaoService.RecuperarSessoes();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPeloID(int id)
        {
            var lerSessaoDTO = _sessaoService.RecuperarSessaoPeloID(id);

            if(lerSessaoDTO == null)
            { return NotFound(); }

            return Ok(lerSessaoDTO);
        }
    }
}