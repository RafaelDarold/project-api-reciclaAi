using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.Empresa;
using project_api_reciclaAi.Exceptions;

namespace project_api_reciclaAi.Services.Empresa
{
    public class EmpresaService : IEmpresaService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public EmpresaService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmpresaResponseDto>> GetAllAsync()
        {
            var empresas = await _context.Empresas
                .Include(e => e.TipoUsuario)
                .ToListAsync();

            return _mapper.Map<List<EmpresaResponseDto>>(empresas);
        }

        public async Task<EmpresaResponseDto> GetByIdAsync(int id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.TipoUsuario)
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException($"Empresa com id {id} não encontrada.");

            return _mapper.Map<EmpresaResponseDto>(empresa);
        }

        public async Task<EmpresaResponseDto> CreateAsync(EmpresaRequestDto dto)
        {
            var emailExiste = await _context.Empresas
                .AnyAsync(e => e.Email == dto.Email);
            if (emailExiste)
                throw new ConflictException("Já existe uma empresa cadastrada com este e-mail.");

            var cnpjExiste = await _context.Empresas
                .AnyAsync(e => e.Cnpj == dto.Cnpj);
            if (cnpjExiste)
                throw new ConflictException("Já existe uma empresa cadastrada com este CNPJ.");

            var empresa = _mapper.Map<Models.Empresa>(dto);
            empresa.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(empresa.Id);
        }

        public async Task<EmpresaResponseDto> UpdateAsync(int id, EmpresaUpdateDto dto)
        {
            var empresa = await _context.Empresas.FindAsync(id)
                ?? throw new NotFoundException($"Empresa com id {id} não encontrada.");

            if (dto.Email != null && dto.Email != empresa.Email)
            {
                var emailExiste = await _context.Empresas
                    .AnyAsync(e => e.Email == dto.Email);
                if (emailExiste)
                    throw new ConflictException("Já existe uma empresa cadastrada com este e-mail.");
            }

            _mapper.Map(dto, empresa);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(empresa.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id)
                ?? throw new NotFoundException($"Empresa com id {id} não encontrada.");

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }
}