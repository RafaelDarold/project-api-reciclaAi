using AutoMapper;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Profiles
{
    public class SolicitacaoProfile : Profile
    {
        public SolicitacaoProfile()
        {
            CreateMap<SolicitacaoRequestDto, Solicitacao>()
                .ForMember(dest => dest.DataSolicitacao, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => "pendente"))
                .ForMember(dest => dest.TiposMaterial, opt => opt.Ignore());

            CreateMap<Solicitacao, SolicitacaoResponseDto>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.EquipeColeta, opt => opt.MapFrom(src => src.EquipeColeta))
                .ForMember(dest => dest.Catador, opt => opt.MapFrom(src => src.Catador))
                .ForMember(dest => dest.TiposMaterial, opt => opt.MapFrom(src =>
                    src.TiposMaterial.Select(t => new SolicitacaoMaterialDto
                    {
                        TipoMaterialId = t.TipoMaterialId,
                        Quantidade = t.Quantidade
                    }).ToList()));
        }
    }
}