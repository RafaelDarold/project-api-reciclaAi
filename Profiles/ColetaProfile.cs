using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class ColetaProfile : Profile
    {
        public ColetaProfile()
        {
            CreateMap<ColetaRequestDto, Coleta>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => "em andamento"))
                .ForMember(dest => dest.PesoTotal, opt => opt.MapFrom(_ => 0))
                .ForMember(dest => dest.TipoMaterial, opt => opt.Ignore());

            CreateMap<Coleta, ColetaResponseDto>()
                .ForMember(dest => dest.Solicitacao, opt => opt.MapFrom(src => src.Solicitacao))
                .ForMember(dest => dest.TiposMaterial, opt => opt.MapFrom(src =>
                    src.TipoMaterial.Select(t => new ColetaMaterialDto
                    {
                        TipoMaterialId = t.TipoMaterialId,
                        Quantidade = t.Quantidade
                    }).ToList()));
        }
    }
}