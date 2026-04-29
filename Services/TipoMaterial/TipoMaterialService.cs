using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.TipoMaterial;
using project_api_reciclaAi.Exceptions;

namespace project_api_reciclaAi.Services.TipoMaterial
{
    public class TipoMaterialService : ITipoMaterialService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public TipoMaterialService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoMaterialResponseDto>> GetAllAsync()
        {
            var materiais = await _context.TiposMaterial.ToListAsync();
            return _mapper.Map<List<TipoMaterialResponseDto>>(materiais);
        }

        public async Task<TipoMaterialResponseDto> GetByIdAsync(int id)
        {
            var material = await _context.TiposMaterial.FindAsync(id)
                ?? throw new NotFoundException($"Tipo de material com id {id} não encontrado.");

            return _mapper.Map<TipoMaterialResponseDto>(material);
        }

        public async Task<TipoMaterialResponseDto> CreateAsync(TipoMaterialRequestDto dto)
        {
            var material = _mapper.Map<Models.TipoMaterial>(dto);
            material.CriadoEm = DateTime.UtcNow;
            material.AtualizadoEm = DateTime.UtcNow;

            _context.TiposMaterial.Add(material);
            await _context.SaveChangesAsync();

            return _mapper.Map<TipoMaterialResponseDto>(material);
        }

        public async Task<TipoMaterialResponseDto> UpdateAsync(int id, TipoMaterialRequestDto dto)
        {
            var material = await _context.TiposMaterial.FindAsync(id)
                ?? throw new NotFoundException($"Tipo de material com id {id} não encontrado.");

            material.Nome = dto.Nome;
            material.Descricao = dto.Descricao;
            material.TipoPeso = dto.TipoPeso;
            material.AtualizadoEm = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return _mapper.Map<TipoMaterialResponseDto>(material);
        }

        public async Task DeleteAsync(int id)
        {
            var material = await _context.TiposMaterial.FindAsync(id)
                ?? throw new NotFoundException($"Tipo de material com id {id} não encontrado.");

            _context.TiposMaterial.Remove(material);
            await _context.SaveChangesAsync();
        }
    }
}