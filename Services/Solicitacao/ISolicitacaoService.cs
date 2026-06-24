using project_api_reciclaAi.Dtos.Solicitacao;

namespace project_api_reciclaAi.Services.Solicitacao
{
    public interface ISolicitacaoService
    {
        Task<PaginatedResponseDto<SolicitacaoResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<SolicitacaoResponseDto> GetByIdAsync(int id);
        Task<PaginatedResponseDto<SolicitacaoResponseDto>> GetByClienteAsync(int clienteId, PaginationQueryDto pagination);
        Task<SolicitacaoResponseDto> CreateAsync(SolicitacaoRequestDto dto);
        Task<SolicitacaoResponseDto> UpdateStatusAsync(int id, SolicitacaoStatusUpdateDto dto);
        Task<SolicitacaoResponseDto> AtribuirEquipeAsync(int id, int equipeId);
        Task DeleteAsync(int id);
    }
}
