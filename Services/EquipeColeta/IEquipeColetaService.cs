using project_api_reciclaAi.Dtos.EquipeColeta;

namespace project_api_reciclaAi.Services.EquipeColeta
{
    public interface IEquipeColetaService
    {
        Task<PaginatedResponseDto<EquipeColetaResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<EquipeColetaResponseDto> GetByIdAsync(int id);
        Task<PaginatedResponseDto<EquipeColetaResponseDto>> GetByEmpresaAsync(int empresaId, PaginationQueryDto pagination);
        Task<EquipeColetaResponseDto> CreateAsync(EquipeColetaRequestDto dto);
        Task<EquipeColetaResponseDto> UpdateAsync(int id, EquipeColetaRequestDto dto);
        Task DeleteAsync(int id);
    }
}
