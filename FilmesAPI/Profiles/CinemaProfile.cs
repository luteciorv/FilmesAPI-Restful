using AutoMapper;
using FilmesAPI.Data.DTOS.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CriarCinemaDTO, Cinema>();
            CreateMap<AtualizarCinemaDTO, Cinema>();
            CreateMap<Cinema, LerCinemaDTO>();
        }
    }
}