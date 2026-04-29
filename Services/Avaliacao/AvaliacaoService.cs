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
            return _context.Avaliacoes
                .Include(a => a.Coleta).ThenInclude(c => c!.Solicitacao)
                .Include(a => a.Cliente);
        }

        public async Task<List<AvaliacaoResponseDto>> GetAllAsync()
        {
            var avaliacoes = await QueryComIncludes().ToListAsync();
            return _mapper.Map<List<AvaliacaoResponseDto>>(avaliacoes);
        }

        public async Task<AvaliacaoResponseDto> GetByIdAsync(int id)
        {
            var avaliacao = await QueryComIncludes()
                .FirstOrDefaultAsync(a => a.Id == id)
                ?? throw new NotFoundException($"Avaliação com id {id} não encontrada.");

            return _mapper.Map<AvaliacaoResponseDto>(avaliacao);
        }

        public async Task<List<AvaliacaoResponseDto>> GetByColetaAsync(int coletaId)
        {
            var coletaExiste = await _context.Coletas.AnyAsync(c => c.Id == coletaId);
            if (!coletaExiste)
                throw new NotFoundException($"Coleta com id {coletaId} não encontrada.");

            var avaliacoes = await QueryComIncludes()
                .Where(a => a.ColetaId == coletaId)
                .ToListAsync();

            return _mapper.Map<List<AvaliacaoResponseDto>>(avaliacoes);
        }

        public async Task<List<AvaliacaoResponseDto>> GetByClienteAsync(int clienteId)
        {
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == clienteId);
            if (!clienteExiste)
                throw new NotFoundException($"Cliente com id {clienteId} não encontrado.");

            var avaliacoes = await QueryComIncludes()
                .Where(a => a.ClienteId == clienteId)
                .ToListAsync();

            return _mapper.Map<List<AvaliacaoResponseDto>>(avaliacoes);
        }

        public async Task<AvaliacaoResponseDto> CreateAsync(AvaliacaoRequestDto dto)
        {
            var coleta = await _context.Coletas
                .Include(c => c.Solicitacao)
                .FirstOrDefaultAsync(c => c.Id == dto.ColetaId)
                ?? throw new NotFoundException($"Coleta com id {dto.ColetaId} não encontrada.");

            if (coleta.Status != "finalizada")
                throw new BusinessException("Só é possível avaliar coletas finalizadas.");

            if (coleta.Solicitacao!.ClienteId != dto.ClienteId)
                throw new BusinessException("O cliente informado não é o dono desta coleta.");

            var jaAvaliou = await _context.Avaliacoes
                .AnyAsync(a => a.ColetaId == dto.ColetaId && a.ClienteId == dto.ClienteId);
            if (jaAvaliou)
                throw new ConflictException("Este cliente já avaliou esta coleta.");

            var avaliacao = _mapper.Map<Models.Avaliacao>(dto);
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(avaliacao.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id)
                ?? throw new NotFoundException($"Avaliação com id {id} não encontrada.");

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
        }
    }
}