using project_api_reciclaAi.Dtos.EquipeColeta;

namespace project_api_reciclaAi.Services.EquipeColeta
{
    public interface IEquipeColetaService
    {
        Task<List<EquipeColetaResponseDto>> GetAllAsync();
        Task<EquipeColetaResponseDto> GetByIdAsync(int id);
        Task<List<EquipeColetaResponseDto>> GetByEmpresaAsync(int empresaId);
        Task<EquipeColetaResponseDto> CreateAsync(EquipeColetaRequestDto dto);
        Task<EquipeColetaResponseDto> UpdateAsync(int id, EquipeColetaRequestDto dto);
        Task DeleteAsync(int id);
    }
}