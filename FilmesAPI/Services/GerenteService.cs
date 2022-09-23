using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public GerenteService(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public LerGerenteDTO CriarGerente(CriarGerenteDTO criarGerenteDTO)
        {
            var gerente = _mapper.Map<Gerente>(criarGerenteDTO);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<LerGerenteDTO>(gerente);
        }

        public LerGerenteDTO RecuperarGerentePeloID(int id)
        {
            var gerente = _context.Gerentes.Find(id);

            if (gerente == null)
            { return null; }

            return _mapper.Map<LerGerenteDTO>(gerente);
        }

        public List<LerGerenteDTO> RecuperarGerentes()
        {
            var gerentes = _context.Gerentes.ToList();
            return _mapper.Map<List<LerGerenteDTO>>(gerentes);
        }

        public Result ApagarGerentePeloID(int id)
        {
            var gerente = _context.Gerentes.Find(id);

            if (gerente == null)
            { return Result.Fail($"O gerente de id {id} não foi encontrado."); }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}