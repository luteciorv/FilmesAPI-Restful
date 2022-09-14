using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;            

        public FilmeService(FilmeContext context)
        {
            _context = context;
        }

        public FilmeService(FilmeContext context, IMapper mapper) : this(context)
        {
            _mapper = mapper;
        }


        public void AdicionarFilme(CriarFilmeDTO filmeDTO)
        {
            var filme = _mapper.Map<Filme>(filmeDTO);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
        }


        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        public Filme RecuperarFilmePeloID(int id)
        {
            return _context.Filmes.Find(id);
        }

        public Filme RecuperarUltimoFilmeAdicionado()
        {
            return _context.Filmes.OrderBy(F => F.ID).LastOrDefault();
        }

        public LerFilmeDTO RecuperarLerFilmeDTO(Filme filme)
        {
            return _mapper.Map<LerFilmeDTO>(filme);
        }


        public void AtualizarFilme(AtualizarFilmeDTO filmeDTO, Filme filme)
        {
            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();
        }


        public void ApagarFilme(Filme filme)
        {
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
        }
    }
}