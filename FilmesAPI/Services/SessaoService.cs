using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public SessaoService(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public LerSessaoDTO AdicionarSessao(CriarSessaoDTO criarSessaoDTO)
        {
            var sessao = _mapper.Map<Sessao>(criarSessaoDTO);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<LerSessaoDTO>(sessao);
        }


        public List<LerSessaoDTO> RecuperarSessoes()
        {
            var sessoes = _context.Sessoes.ToList();
            return _mapper.Map<List<LerSessaoDTO>>(sessoes);
        }

        public LerSessaoDTO RecuperarSessaoPeloID(int id)
        {
            var sessao = _context.Sessoes.Find(id);

            if (sessao == null)
            { return null; }

            return _mapper.Map<LerSessaoDTO>(sessao);
        }
    }
}
