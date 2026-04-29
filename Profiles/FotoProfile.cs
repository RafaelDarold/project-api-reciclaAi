using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class FotoProfile : Profile
    {
        public FotoProfile()
        {
            CreateMap<FotoRequestDto, Foto>();
            CreateMap<Foto, FotoResponseDto>();
        }
    }
}