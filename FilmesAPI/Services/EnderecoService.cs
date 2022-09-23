using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public EnderecoService(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public LerEnderecoDTO AdicionarEndereco(CriarEnderecoDTO criarEnderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(criarEnderecoDTO);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<LerEnderecoDTO>(endereco);
        }

        public IEnumerable<Endereco> RecuperarEnderecos()
        {
            return _context.Enderecos;
        }

        public LerEnderecoDTO RecuperarEnderecoPeloID(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            { return null; }

            return _mapper.Map<LerEnderecoDTO>(endereco);
        }

        public Result AtualizarEndereco(int id, AtualizarEnderecoDTO atualizarEnderecoDTO)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            { return Result.Fail($"O endereço de id {id} não foi encontrado."); }

            _mapper.Map(atualizarEnderecoDTO, endereco);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result ApagarEnderecoPeloID(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            { return Result.Fail($"O endereço de id {id} não foi encontrado."); }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}