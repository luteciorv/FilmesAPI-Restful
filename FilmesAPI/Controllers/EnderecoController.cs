using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Data.DTOS.Endereco;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public EnderecoController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CriarEnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarEnderecoPeloID), new { endereco.ID }, endereco);
        }


        [HttpGet]
        public IEnumerable<Endereco> RecuperarEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPeloID(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarEnderecoPeloID(int id, [FromBody] AtualizarEnderecoDTO enderecoDTO)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            {
                return NotFound();
            }

            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult ApagarEnderecoPeloID(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return Ok();
        }
    }
}