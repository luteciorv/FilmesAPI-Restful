using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public FilmeService(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public LerFilmeDTO AdicionarFilme(CriarFilmeDTO filmeDTO)
        {
            var filme = _mapper.Map<Filme>(filmeDTO);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<LerFilmeDTO>(filme);
        }


        public List<LerFilmeDTO> RecuperarFilmes(int? classificacaoEtaria)
        {
            var filmes = _context.Filmes.AsEnumerable();

            if (classificacaoEtaria != null)
            {
                filmes = filmes.Where(F => F.ClassificacaoEtaria <= classificacaoEtaria);
            }            

            if (filmes == null)
            { return null; }

            return _mapper.Map<List<LerFilmeDTO>>(filmes.ToList());
        }

        public LerFilmeDTO RecuperarFilmePeloID(int id)
        {
            var filme = _context.Filmes.Find(id);

            if(filme == null)
            { return null; }

            return _mapper.Map<LerFilmeDTO>(filme);           
        }


        public Result AtualizarFilme(int id, AtualizarFilmeDTO filmeDTO)
        {
            var filme = _context.Filmes.Find(id);

            if(filme == null)
            { return Result.Fail($"O filme de id {id} não foi encontrado"); }

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();

            return Result.Ok();
        }


        public Result ApagarFilme(int id)
        {
            var filme = _context.Filmes.Find(id);

            if(filme == null)
            { return Result.Fail($"O filme de id {id} não foi encontrado"); }

            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}