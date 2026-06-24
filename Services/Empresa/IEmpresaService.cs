using project_api_reciclaAi.Dtos.Empresa;

namespace project_api_reciclaAi.Services.Empresa
{
    public interface IEmpresaService
    {
        Task<PaginatedResponseDto<EmpresaResponseDto>> GetAllAsync(PaginationQueryDto pagination);
        Task<EmpresaResponseDto> GetByIdAsync(int id);
        Task<EmpresaResponseDto> CreateAsync(EmpresaRequestDto dto);
        Task<EmpresaResponseDto> UpdateAsync(int id, EmpresaUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
