using project_api_reciclaAi.Dtos.TipoMaterial;

namespace project_api_reciclaAi.Services.TipoMaterial
{
    public interface ITipoMaterialService
    {
        Task<PaginatedResponseDto<TipoMaterialResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<TipoMaterialResponseDto> GetByIdAsync(int id);
        Task<TipoMaterialResponseDto> CreateAsync(TipoMaterialRequestDto dto);
        Task<TipoMaterialResponseDto> UpdateAsync(int id, TipoMaterialRequestDto dto);
        Task DeleteAsync(int id);
    }
}
