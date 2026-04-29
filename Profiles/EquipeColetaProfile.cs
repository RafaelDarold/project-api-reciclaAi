using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class EquipeColetaProfile : Profile
    {
        public EquipeColetaProfile()
        {
            CreateMap<EquipeColetaRequestDto, EquipeColeta>();

            CreateMap<EquipeColeta, EquipeColetaResponseDto>()
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa));
        }
    }
}