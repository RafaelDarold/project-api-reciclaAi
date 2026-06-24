using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.Avaliacao;
using project_api_reciclaAi.Exceptions;

namespace project_api_reciclaAi.Services.Avaliacao
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public AvaliacaoService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<Models.Avaliacao> QueryComIncludes()
        {
            return _context.Avaliacao
                .Include(a => a.Coleta).ThenInclude(c => c!.Solicitacao)
                .Include(a => a.Cliente);
        }

        public async Task<PaginatedResponseDto<AvaliacaoResponseDto>> GetAllAsync(PaginationQueryDto pagination)
        {
            return await QueryComIncludes()
                .ToPaginatedResponseAsync<Models.Avaliacao, AvaliacaoResponseDto>(pagination, _mapper);
        }

        public async Task<AvaliacaoResponseDto> GetByIdAsync(int id)
        {
            var avaliacao = await QueryComIncludes()
                .FirstOrDefaultAsync(a => a.Id == id)
                ?? throw new NotFoundException($"Avaliação com id {id} não encontrada.");

            return _mapper.Map<AvaliacaoResponseDto>(avaliacao);
        }

        public async Task<PaginatedResponseDto<AvaliacaoResponseDto>> GetByColetaAsync(int coletaId, PaginationQueryDto pagination)
        {
            var coletaExiste = await _context.Coleta.AnyAsync(c => c.Id == coletaId);
            if (!coletaExiste)
                throw new NotFoundException($"Coleta com id {coletaId} não encontrada.");

            var query = QueryComIncludes()
                .Where(a => a.ColetaId == coletaId);

            return await query.ToPaginatedResponseAsync<Models.Avaliacao, AvaliacaoResponseDto>(pagination, _mapper);
        }

        public async Task<PaginatedResponseDto<AvaliacaoResponseDto>> GetByClienteAsync(int clienteId, PaginationQueryDto pagination)
        {
            var clienteExiste = await _context.Cliente.AnyAsync(c => c.Id == clienteId);
            if (!clienteExiste)
                throw new NotFoundException($"Cliente com id {clienteId} não encontrado.");

            var query = QueryComIncludes()
                .Where(a => a.ClienteId == clienteId);

            return await query.ToPaginatedResponseAsync<Models.Avaliacao, AvaliacaoResponseDto>(pagination, _mapper);
        }

        public async Task<AvaliacaoResponseDto> CreateAsync(AvaliacaoRequestDto dto)
        {
            var coleta = await _context.Coleta
                .Include(c => c.Solicitacao)
                .FirstOrDefaultAsync(c => c.Id == dto.ColetaId)
                ?? throw new NotFoundException($"Coleta com id {dto.ColetaId} não encontrada.");

            if (coleta.Status != "finalizada")
                throw new BusinessException("Só é possível avaliar coletas finalizadas.");

            if (coleta.Solicitacao!.ClienteId != dto.ClienteId)
                throw new BusinessException("O cliente informado não é o dono desta coleta.");

            var jaAvaliou = await _context.Avaliacao
                .AnyAsync(a => a.ColetaId == dto.ColetaId && a.ClienteId == dto.ClienteId);
            if (jaAvaliou)
                throw new ConflictException("Este cliente já avaliou esta coleta.");

            var avaliacao = _mapper.Map<Models.Avaliacao>(dto);
            _context.Avaliacao.Add(avaliacao);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(avaliacao.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var avaliacao = await _context.Avaliacao.FindAsync(id)
                ?? throw new NotFoundException($"Avaliação com id {id} não encontrada.");

            _context.Avaliacao.Remove(avaliacao);
            await _context.SaveChangesAsync();
        }
    }
}