using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<EmpresaRequestDto, Empresa>();

            CreateMap<EmpresaUpdateDto, Empresa>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Empresa, EmpresaResponseDto>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario));
        }
    }
}