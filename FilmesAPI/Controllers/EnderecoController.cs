using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Services;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {        
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CriarEnderecoDTO criarEnderecoDTO)
        {
            var lerEnderecoDTO = _enderecoService.AdicionarEndereco(criarEnderecoDTO);

            return CreatedAtAction(nameof(RecuperarEnderecoPeloID), new { lerEnderecoDTO.ID }, lerEnderecoDTO);
        }


        [HttpGet]
        public IEnumerable<Endereco> RecuperarEnderecos()
        {
            return _enderecoService.RecuperarEnderecos();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPeloID(int id)
        {
            var lerEnderecoDTO = _enderecoService.RecuperarEnderecoPeloID(id);

            if(lerEnderecoDTO == null)
            { return NotFound(); }

            return Ok(lerEnderecoDTO);
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] AtualizarEnderecoDTO atualizarEnderecoDTO)
        {
            var resultado = _enderecoService.AtualizarEndereco(id, atualizarEnderecoDTO);

            if(resultado.IsFailed)
            { return NotFound(); }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult ApagarEnderecoPeloID(int id)
        {
            var resultado = _enderecoService.ApagarEnderecoPeloID(id);

            if(resultado.IsFailed)
            { return NotFound(); }

            return NoContent();
        }
    }
}