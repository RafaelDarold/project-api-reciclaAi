using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.EquipeColeta;
using project_api_reciclaAi.Exceptions;

namespace project_api_reciclaAi.Services.EquipeColeta
{
    public class EquipeColetaService : IEquipeColetaService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public EquipeColetaService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EquipeColetaResponseDto>> GetAllAsync()
        {
            var equipes = await _context.EquipeColeta
                .Include(e => e.Empresa)
                .ToListAsync();

            return _mapper.Map<List<EquipeColetaResponseDto>>(equipes);
        }

        public async Task<EquipeColetaResponseDto> GetByIdAsync(int id)
        {
            var equipe = await _context.EquipeColeta
                .Include(e => e.Empresa)
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException($"Equipe de coleta com id {id} não encontrada.");

            return _mapper.Map<EquipeColetaResponseDto>(equipe);
        }

        public async Task<List<EquipeColetaResponseDto>> GetByEmpresaAsync(int empresaId)
        {
            var empresaExiste = await _context.Empresa.AnyAsync(e => e.Id == empresaId);
            if (!empresaExiste)
                throw new NotFoundException($"Empresa com id {empresaId} não encontrada.");

            var equipes = await _context.EquipeColeta
                .Include(e => e.Empresa)
                .Where(e => e.EmpresaId == empresaId)
                .ToListAsync();

            return _mapper.Map<List<EquipeColetaResponseDto>>(equipes);
        }

        public async Task<EquipeColetaResponseDto> CreateAsync(EquipeColetaRequestDto dto)
        {
            var empresaExiste = await _context.Empresa.AnyAsync(e => e.Id == dto.EmpresaId);
            if (!empresaExiste)
                throw new NotFoundException($"Empresa com id {dto.EmpresaId} não encontrada.");

            var equipe = _mapper.Map<Models.EquipeColeta>(dto);

            _context.EquipeColeta.Add(equipe);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(equipe.Id);
        }

        public async Task<EquipeColetaResponseDto> UpdateAsync(int id, EquipeColetaRequestDto dto)
        {
            var equipe = await _context.EquipeColeta.FindAsync(id)
                ?? throw new NotFoundException($"Equipe de coleta com id {id} não encontrada.");

            var empresaExiste = await _context.Empresa.AnyAsync(e => e.Id == dto.EmpresaId);
            if (!empresaExiste)
                throw new NotFoundException($"Empresa com id {dto.EmpresaId} não encontrada.");

            _mapper.Map(dto, equipe);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(equipe.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var equipe = await _context.EquipeColeta.FindAsync(id)
                ?? throw new NotFoundException($"Equipe de coleta com id {id} não encontrada.");

            _context.EquipeColeta.Remove(equipe);
            await _context.SaveChangesAsync();
        }
    }
}