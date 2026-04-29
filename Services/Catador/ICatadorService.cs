using project_api_reciclaAi.Dtos.Catador;

namespace project_api_reciclaAi.Services.Catador
{
    public interface ICatadorService
    {
        Task<List<CatadorResponseDto>> GetAllAsync();
        Task<CatadorResponseDto> GetByIdAsync(int id);
        Task<CatadorResponseDto> CreateAsync(CatadorRequestDto dto);
        Task DeleteAsync(int id);
    }
}