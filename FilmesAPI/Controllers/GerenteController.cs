using FilmesAPI.Data.DTOS;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult CriarGerente([FromBody] CriarGerenteDTO criarGerenteDTO)
        {
            var lerGerenteDTO = _gerenteService.CriarGerente(criarGerenteDTO);

            return CreatedAtAction(nameof(RecuperarGerentePeloID), new { lerGerenteDTO.ID }, lerGerenteDTO);
        }

        [HttpGet]
        public List<LerGerenteDTO> RecuperarGerentes()
        {
            return _gerenteService.RecuperarGerentes();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePeloID(int id)
        {
            var lerGerenteDTO = _gerenteService.RecuperarGerentePeloID(id);

            if(lerGerenteDTO == null)
            { return NotFound(); }

            return Ok(lerGerenteDTO);
        }


        [HttpDelete("{id}")]
        public IActionResult ApagarGerentePeloID(int id)
        {
            var resultado = _gerenteService.ApagarGerentePeloID(id);

            if(resultado.IsFailed)
            { return NotFound(); }
                
            return NoContent();
        }
    }
}