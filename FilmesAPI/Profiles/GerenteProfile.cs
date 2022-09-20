using AutoMapper;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using System.Linq;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CriarGerenteDTO, Gerente>();
            CreateMap<Gerente, LerGerenteDTO>()
                .ForMember(G => G.Cinemas, O => O
                .MapFrom(G => G.Cinemas.Select
                (C => new
                {
                    C.ID,
                    C.Nome,
                    C.EnderecoID,
                    C.Endereco
                })));
        }
    }
}