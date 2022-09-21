using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Services;
using AutoMapper;
using FilmesAPI.Data.DTOS;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly FilmeService _filmeService;        

        public FilmeController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _filmeService = new FilmeService(context, mapper);
        }


        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CriarFilmeDTO filmeDTO)
        {
            _filmeService.AdicionarFilme(filmeDTO);

            var filme = _filmeService.RecuperarUltimoFilmeAdicionado();

            return CreatedAtAction(nameof(RecuperarFilmePeloID), new { filme.ID }, filme);
        }


        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
            if(classificacaoEtaria == null)
            {
                filmes = _filmeService.RecuperarFilmes().ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(F => F.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if(filmes == null)
            {
                return NotFound();
            }

            var filmesDTO = _mapper.Map<List<LerFilmeDTO>>(filmes);

            return Ok(filmesDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePeloID(int id)
        {
            var filme = _filmeService.RecuperarFilmePeloID(id);

            if (filme != null) 
            {
                var filmeDTO = _filmeService.RecuperarLerFilmeDTO(filme);
                
                return Ok(filmeDTO); 
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarFilmePeloID(int id, [FromBody] AtualizarFilmeDTO filmeDTO)
        {
            var filme = _filmeService.RecuperarFilmePeloID(id);

            if (filme == null)
            {
                return NotFound();
            }

            _filmeService.AtualizarFilme(filmeDTO, filme);            

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult ApagarFilmePeloID(int id)
        {
            var filme = _filmeService.RecuperarFilmePeloID(id);

            if (filme == null)
            {
                return NotFound();
            }

            _filmeService.ApagarFilme(filme);
            return Ok();
        }
    }
}