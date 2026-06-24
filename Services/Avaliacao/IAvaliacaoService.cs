using project_api_reciclaAi.Dtos.Avaliacao;

namespace project_api_reciclaAi.Services.Avaliacao
{
    public interface IAvaliacaoService
    {
        Task<PaginatedResponseDto<AvaliacaoResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<AvaliacaoResponseDto> GetByIdAsync(int id);
        Task<PaginatedResponseDto<AvaliacaoResponseDto>> GetByColetaAsync(int coletaId, PaginationQueryDto pagination);
        Task<PaginatedResponseDto<AvaliacaoResponseDto>> GetByClienteAsync(int clienteId, PaginationQueryDto pagination);
        Task<AvaliacaoResponseDto> CreateAsync(AvaliacaoRequestDto dto);
        Task DeleteAsync(int id);
    }
}
