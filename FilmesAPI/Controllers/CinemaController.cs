using FilmesAPI.Data.DTOS;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CriarCinemaDTO criarCinemaDTO)
        {
            var lerCinemaDTO = _cinemaService.AdicionarCinema(criarCinemaDTO);

            return CreatedAtAction(nameof(RecuperarCinemaPeloID), new { lerCinemaDTO.ID }, lerCinemaDTO);
        }


        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeFilme)
        {
            var lerCinemasDTO = _cinemaService.RecuperarCinemas(nomeFilme);

            if(lerCinemasDTO == null)
            { return NotFound(); }

            return Ok(lerCinemasDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPeloID(int id)
        {
            var lerCinemaDTO = _cinemaService.RecuperarCinemaPeloID(id);

            if(lerCinemaDTO == null)
            { return NotFound(); }

            return Ok(lerCinemaDTO);
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] AtualizarCinemaDTO atualizarCinemaDTO)
        {
            var resultado = _cinemaService.AtualizarCinema(id, atualizarCinemaDTO);
            
            if(resultado.IsFailed)
            { return NotFound(); }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult ApagarCinemaPeloID(int id)
        {
            var resultado = _cinemaService.ApagarCinemaPeloID(id);

            if(resultado.IsFailed)
            { return NotFound(); }

            return NoContent();
        }
    }
}