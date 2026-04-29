using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class CatadorProfile : Profile
    {
        public CatadorProfile()
        {
            CreateMap<CatadorRequestDto, Catador>();

            CreateMap<Catador, CatadorResponseDto>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario))
                .ForMember(dest => dest.EquipeColeta, opt => opt.MapFrom(src => src.EquipeColeta));
        }
    }
}