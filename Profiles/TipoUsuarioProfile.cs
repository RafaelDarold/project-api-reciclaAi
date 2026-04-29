using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class TipoUsuarioProfile : Profile
    {
        public TipoUsuarioProfile()
        {
            CreateMap<TipoUsuario, TipoUsuarioResponseDto>();
        }
    }
}