using project_api_reciclaAi.Dtos.Avaliacao;

namespace project_api_reciclaAi.Services.Avaliacao
{
    public interface IAvaliacaoService
    {
        Task<List<AvaliacaoResponseDto>> GetAllAsync();
        Task<AvaliacaoResponseDto> GetByIdAsync(int id);
        Task<List<AvaliacaoResponseDto>> GetByColetaAsync(int coletaId);
        Task<List<AvaliacaoResponseDto>> GetByClienteAsync(int clienteId);
        Task<AvaliacaoResponseDto> CreateAsync(AvaliacaoRequestDto dto);
        Task DeleteAsync(int id);
    }
}