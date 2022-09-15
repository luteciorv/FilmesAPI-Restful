using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS.Filme;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;            

        public FilmeService(APIContext context)
        {
            _context = context;
        }

        public FilmeService(APIContext context, IMapper mapper) : this(context)
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