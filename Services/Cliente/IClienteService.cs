using project_api_reciclaAi.Dtos.Cliente;

namespace project_api_reciclaAi.Services.Cliente
{
    public interface IClienteService
    {
        Task<PaginatedResponseDto<ClienteResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<ClienteResponseDto> GetByIdAsync(int id);
        Task<ClienteResponseDto> CreateAsync(ClienteRequestDto dto);
        Task<ClienteResponseDto> UpdateAsync(int id, ClienteUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
