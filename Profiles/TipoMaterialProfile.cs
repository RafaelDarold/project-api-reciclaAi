using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class TipoMaterialProfile : Profile
    {
        public TipoMaterialProfile()
        {
            CreateMap<TipoMaterialRequestDto, TipoMaterial>()
                .ForMember(dest => dest.CriadoEm, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.AtualizadoEm, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<TipoMaterial, TipoMaterialResponseDto>();
        }
    }
}