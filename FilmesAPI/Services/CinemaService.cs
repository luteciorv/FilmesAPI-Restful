using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public CinemaService(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public LerCinemaDTO AdicionarCinema(CriarCinemaDTO criarCinemaDTO)
        {
            var cinema = _mapper.Map<Cinema>(criarCinemaDTO);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<LerCinemaDTO>(cinema);
        }


        public List<LerCinemaDTO> RecuperarCinemas(string nomeFilme)
        {
            var cinemas = _context.Cinemas.AsEnumerable();
            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeFilme))
            {
                cinemas = cinemas.Where(C => C.Sessoes.Any(S => S.Filme.Titulo == nomeFilme));                
            }

            return _mapper.Map<List<LerCinemaDTO>>(cinemas.ToList());
        }

        public LerCinemaDTO RecuperarCinemaPeloID(int id)
        {
            var cinema = _context.Cinemas.Find(id);

            if (cinema == null)
            {
                return null;
            }

            return _mapper.Map<LerCinemaDTO>(cinema);
        }

        public Result AtualizarCinema(int id, AtualizarCinemaDTO atualizarCinemaDTO)
        {
            var cinema = _context.Cinemas.Find(id);

            if (cinema == null)
            { return Result.Fail($"O cinema de id {id} não foi encontrado."); }

            _mapper.Map(atualizarCinemaDTO, cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result ApagarCinemaPeloID(int id)
        {
            var cinema = _context.Cinemas.Find(id);

            if (cinema == null)
            { return Result.Fail($"O cinema de id {id} não foi encontrado."); }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
