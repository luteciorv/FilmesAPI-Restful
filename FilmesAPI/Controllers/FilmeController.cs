﻿using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Services;
using FilmesAPI.Data.DTOS;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;        

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionarFilme([FromBody] CriarFilmeDTO filmeDTO)
        {
            var lerFilmeDTO = _filmeService.AdicionarFilme(filmeDTO);
           
            return CreatedAtAction(nameof(RecuperarFilmePeloID), new { lerFilmeDTO.ID }, lerFilmeDTO);
        }


        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var lerfilmesDTO = _filmeService.RecuperarFilmes(classificacaoEtaria);

            if (lerfilmesDTO == null)
            { NotFound(); }
            
            return Ok(lerfilmesDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePeloID(int id)
        {
            var lerFilmeDTO = _filmeService.RecuperarFilmePeloID(id);

            if(lerFilmeDTO == null)
            { NotFound(); }

            return Ok(lerFilmeDTO);           
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] AtualizarFilmeDTO atualizarFilmeDTO)
        {           
            var resultado = _filmeService.AtualizarFilme(id, atualizarFilmeDTO);            

            if(resultado.IsFailed)
            { NotFound(); }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult ApagarFilmePeloID(int id)
        {
            var resultado = _filmeService.ApagarFilme(id);

            if (resultado.IsFailed)
            { return NotFound(); }
            
            return NoContent();
        }
    }
}