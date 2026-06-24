using project_api_reciclaAi.Dtos.Coleta;

namespace project_api_reciclaAi.Services.Coleta
{
    public interface IColetaService
    {
        Task<PaginatedResponseDto<ColetaResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<ColetaResponseDto> GetByIdAsync(int id);
        Task<ColetaResponseDto> GetBySolicitacaoAsync(int solicitacaoId);
        Task<ColetaResponseDto> CreateAsync(ColetaRequestDto dto);
        Task<ColetaResponseDto> FinalizarAsync(int id);
        Task DeleteAsync(int id);
    }
}
