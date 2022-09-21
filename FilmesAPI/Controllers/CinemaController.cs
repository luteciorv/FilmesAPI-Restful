using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public CinemaController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CriarCinemaDTO cinemaDTO)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDTO);
            
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarCinemaPeloID), new { cinema.ID }, cinema);
        }


        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if(cinemas == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(nomeFilme))
            {
                var consulta = (from C in cinemas
                                where C.Sessoes.Any(S => S.Filme.Titulo == nomeFilme)
                                select C);

                cinemas = consulta.ToList();
            }

            var cinemaDTO = _mapper.Map<List<LerCinemaDTO>>(cinemas);

            return Ok(cinemaDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPeloID(int id)
        {
            var cinema = _context.Cinemas.Find(id);

            if(cinema == null)
            {
                return NotFound();
            }

            var cinemaDTO = _mapper.Map<LerCinemaDTO>(cinema);
            return Ok(cinemaDTO);
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarCinemaPeloID(int id, [FromBody] AtualizarCinemaDTO cinemaDTO)
        {
            var cinema = _context.Cinemas.Find(id);

            if(cinema == null)
            {
                return NotFound();
            }

            _mapper.Map(cinemaDTO, cinema);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult ApagarCinemaPeloID(int id)
        {
            var cinema = _context.Cinemas.Find(id);

            if(cinema == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return Ok();
        }
    }
}