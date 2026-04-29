using project_api_reciclaAi.Dtos.TipoUsuario;

namespace project_api_reciclaAi.Services.TipoUsuario
{
    public interface ITipoUsuarioService
    {
        Task<List<TipoUsuarioResponseDto>> GetAllAsync();
        Task<TipoUsuarioResponseDto> GetByIdAsync(int id);
    }
}