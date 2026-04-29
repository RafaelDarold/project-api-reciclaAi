using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoRequestDto, Endereco>();
            CreateMap<Endereco, EnderecoResponseDto>();
        }
    }
}