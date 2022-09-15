using AutoMapper;
using FilmesAPI.Data.DTOS.Endereco;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CriarEnderecoDTO, Endereco>();
            CreateMap<AtualizarEnderecoDTO, Endereco>();
            CreateMap<Endereco, LerEnderecoDTO>();
        }
    }
}