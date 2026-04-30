using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteRequestDto, Cliente>()
                .ForMember(dest => dest.Endereco, opt => opt.Ignore());

            CreateMap<ClienteUpdateDto, Cliente>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Cliente, ClienteResponseDto>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario))
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src =>
                    src.Endereco.Select(e => e.Endereco).ToList()));
        }
    }
}