using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.Catador;
using project_api_reciclaAi.Exceptions;

namespace project_api_reciclaAi.Services.Catador
{
    public class CatadorService : ICatadorService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public CatadorService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponseDto<CatadorResponseDto>> GetAllAsync(PaginationQueryDto pagination)
        {
            var query = _context.Catador
                .Include(c => c.TipoUsuario)
                .Include(c => c.EquipeColeta)
                    .ThenInclude(eq => eq!.Empresa);

            return await query.ToPaginatedResponseAsync<Models.Catador, CatadorResponseDto>(pagination, _mapper);
        }

        public async Task<CatadorResponseDto> GetByIdAsync(int id)
        {
            var catador = await _context.Catador
                .Include(c => c.TipoUsuario)
                .Include(c => c.EquipeColeta)
                    .ThenInclude(eq => eq!.Empresa)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new NotFoundException($"Catador com id {id} não encontrado.");

            return _mapper.Map<CatadorResponseDto>(catador);
        }

        public async Task<CatadorResponseDto> CreateAsync(CatadorRequestDto dto)
        {
            var emailExiste = await _context.Catador
                .AnyAsync(c => c.Email == dto.Email);
            if (emailExiste)
                throw new ConflictException("Já existe um catador cadastrado com este e-mail.");

            var cpfExiste = await _context.Catador
                .AnyAsync(c => c.CpfCnpj == dto.CpfCnpj);
            if (cpfExiste)
                throw new ConflictException("Já existe um catador cadastrado com este CPF.");

            var equipeExiste = await _context.EquipeColeta
                .AnyAsync(e => e.Id == dto.EquipeColetaId);
            if (!equipeExiste)
                throw new NotFoundException($"Equipe de coleta com id {dto.EquipeColetaId} não encontrada.");

            var catador = _mapper.Map<Models.Catador>(dto);
            catador.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            _context.Catador.Add(catador);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(catador.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var catador = await _context.Catador.FindAsync(id)
                ?? throw new NotFoundException($"Catador com id {id} não encontrado.");

            _context.Catador.Remove(catador);
            await _context.SaveChangesAsync();
        }
    }
}