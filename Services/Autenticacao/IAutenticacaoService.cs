using project_api_reciclaAi.Dtos.Autenticacao;

namespace project_api_reciclaAi.Services.Autenticacao
{
    public interface IAutenticacaoService
    {
        Task<GerarChaveResponseDto> GerarChaveAsync(GerarChaveRequestDto dto);
    }
}
