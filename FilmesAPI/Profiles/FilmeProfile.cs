using AutoMapper;
using FilmesAPI.Data.DTOS.Filme;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CriarFilmeDTO, Filme>();
            CreateMap<AtualizarFilmeDTO, Filme>();
            CreateMap<Filme, LerFilmeDTO>();
        }
    }
}
