using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<AvaliacaoRequestDto, Avaliacao>();

            CreateMap<Avaliacao, AvaliacaoResponseDto>()
                .ForMember(dest => dest.Coleta, opt => opt.MapFrom(src => src.Coleta))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente));
        }
    }
}