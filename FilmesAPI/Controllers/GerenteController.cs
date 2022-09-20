using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public GerenteController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CriarGerente([FromBody] CriarGerenteDTO gerenteDTO)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDTO);          

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarGerentePeloID), new { gerente.ID }, gerente);
        }


        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePeloID(int id)
        {
            var gerente = _context.Gerentes.Find(id);

            if(gerente == null)
            {
                return NotFound();
            }

            var gerenteDTO = _mapper.Map<LerGerenteDTO>(gerente);
            return Ok(gerenteDTO);
        }



        [HttpDelete("{id}")]
        public IActionResult ApagarGerentePeloID(int id)
        {
            var gerente = _context.Gerentes.Find(id);

            if (gerente == null)
            {
                return NotFound();
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
                
            return Ok();
        }
    }
}