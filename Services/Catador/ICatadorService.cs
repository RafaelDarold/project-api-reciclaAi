using project_api_reciclaAi.Dtos.Catador;

namespace project_api_reciclaAi.Services.Catador
{
    public interface ICatadorService
    {
        Task<PaginatedResponseDto<CatadorResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<CatadorResponseDto> GetByIdAsync(int id);
        Task<CatadorResponseDto> CreateAsync(CatadorRequestDto dto);
        Task DeleteAsync(int id);
    }
}
