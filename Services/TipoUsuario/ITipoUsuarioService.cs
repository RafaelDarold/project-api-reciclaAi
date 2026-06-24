using project_api_reciclaAi.Dtos.TipoUsuario;

namespace project_api_reciclaAi.Services.TipoUsuario
{
    public interface ITipoUsuarioService
    {
        Task<PaginatedResponseDto<TipoUsuarioResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<TipoUsuarioResponseDto> GetByIdAsync(int id);
    }
}
