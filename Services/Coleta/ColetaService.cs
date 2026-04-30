using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.Coleta;
using project_api_reciclaAi.Exceptions;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Services.Coleta
{
    public class ColetaService : IColetaService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public ColetaService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<Models.Coleta> QueryComIncludes()
        {
            return _context.Coleta
                .Include(c => c.Solicitacao).ThenInclude(s => s!.Cliente)
                .Include(c => c.Solicitacao).ThenInclude(s => s!.Endereco)
                .Include(c => c.TipoMaterial);
        }

        public async Task<List<ColetaResponseDto>> GetAllAsync()
        {
            var coletas = await QueryComIncludes().ToListAsync();
            return _mapper.Map<List<ColetaResponseDto>>(coletas);
        }

        public async Task<ColetaResponseDto> GetByIdAsync(int id)
        {
            var coleta = await QueryComIncludes()
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new NotFoundException($"Coleta com id {id} não encontrada.");

            return _mapper.Map<ColetaResponseDto>(coleta);
        }

        public async Task<ColetaResponseDto> GetBySolicitacaoAsync(int solicitacaoId)
        {
            var coleta = await QueryComIncludes()
                .FirstOrDefaultAsync(c => c.SolicitacaoId == solicitacaoId)
                ?? throw new NotFoundException($"Coleta para solicitação {solicitacaoId} não encontrada.");

            return _mapper.Map<ColetaResponseDto>(coleta);
        }

        public async Task<ColetaResponseDto> CreateAsync(ColetaRequestDto dto)
        {
            var solicitacao = await _context.Solicitacao.FindAsync(dto.SolicitacaoId)
                ?? throw new NotFoundException($"Solicitação com id {dto.SolicitacaoId} não encontrada.");

            if (solicitacao.Status != "em andamento")
                throw new BusinessException("Só é possível criar uma coleta para solicitações em andamento.");

            var coleta = _mapper.Map<Models.Coleta>(dto);
            _context.Coleta.Add(coleta);
            await _context.SaveChangesAsync();

            foreach (var material in dto.TiposMaterial)
            {
                _context.ColetaTipoMaterial.Add(new ColetaTipoMaterial
                {
                    ColetaId = coleta.Id,
                    TipoMaterialId = material.TipoMaterialId,
                    Quantidade = material.Quantidade
                });
            }
            await _context.SaveChangesAsync();

            return await GetByIdAsync(coleta.Id);
        }

        public async Task<ColetaResponseDto> FinalizarAsync(int id)
        {
            var coleta = await _context.Coleta
                .Include(c => c.TipoMaterial)
                .Include(c => c.Solicitacao)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new NotFoundException($"Coleta com id {id} não encontrada.");

            if (coleta.Status == "finalizada")
                throw new BusinessException("Esta coleta já foi finalizada.");

            coleta.PesoTotal = coleta.TipoMaterial.Sum(t => t.Quantidade);
            coleta.Status = "finalizada";
            coleta.Solicitacao!.Status = "concluída";

            await _context.SaveChangesAsync();

            return await GetByIdAsync(coleta.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var coleta = await _context.Coleta.FindAsync(id)
                ?? throw new NotFoundException($"Coleta com id {id} não encontrada.");

            if (coleta.Status == "finalizada")
                throw new BusinessException("Não é possível excluir uma coleta já finalizada.");

            _context.Coleta.Remove(coleta);
            await _context.SaveChangesAsync();
        }
    }
}