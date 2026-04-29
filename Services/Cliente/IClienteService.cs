using project_api_reciclaAi.Dtos.Cliente;

namespace project_api_reciclaAi.Services.Cliente
{
    public interface IClienteService
    {
        Task<List<ClienteResponseDto>> GetAllAsync();
        Task<ClienteResponseDto> GetByIdAsync(int id);
        Task<ClienteResponseDto> CreateAsync(ClienteRequestDto dto);
        Task<ClienteResponseDto> UpdateAsync(int id, ClienteUpdateDto dto);
        Task DeleteAsync(int id);
    }
}