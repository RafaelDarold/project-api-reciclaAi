using project_api_reciclaAi.Dtos.TipoMaterial;

namespace project_api_reciclaAi.Services.TipoMaterial
{
    public interface ITipoMaterialService
    {
        Task<List<TipoMaterialResponseDto>> GetAllAsync();
        Task<TipoMaterialResponseDto> GetByIdAsync(int id);
        Task<TipoMaterialResponseDto> CreateAsync(TipoMaterialRequestDto dto);
        Task<TipoMaterialResponseDto> UpdateAsync(int id, TipoMaterialRequestDto dto);
        Task DeleteAsync(int id);
    }
}