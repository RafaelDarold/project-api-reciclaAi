using project_api_reciclaAi.Dtos.Solicitacao;

namespace project_api_reciclaAi.Services.Solicitacao
{
    public interface ISolicitacaoService
    {
        Task<List<SolicitacaoResponseDto>> GetAllAsync();
        Task<SolicitacaoResponseDto> GetByIdAsync(int id);
        Task<List<SolicitacaoResponseDto>> GetByClienteAsync(int clienteId);
        Task<SolicitacaoResponseDto> CreateAsync(SolicitacaoRequestDto dto);
        Task<SolicitacaoResponseDto> UpdateStatusAsync(int id, SolicitacaoStatusUpdateDto dto);
        Task<SolicitacaoResponseDto> AtribuirEquipeAsync(int id, int equipeId);
        Task DeleteAsync(int id);
    }
}