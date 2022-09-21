using AutoMapper;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CriarSessaoDTO, Sessao>();
            CreateMap<Sessao, LerSessaoDTO>()
                .ForMember(DTO => DTO.HorarioInicioSessao, O =>
                O.MapFrom(S => 
                S.HorarioEncerramentoSessao.AddMinutes(S.Filme.DuracaoEmMinutos * (-1))));
        }
    }
}
