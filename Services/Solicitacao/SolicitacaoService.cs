using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.Solicitacao;
using project_api_reciclaAi.Exceptions;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Services.Solicitacao
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public SolicitacaoService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<Models.Solicitacao> QueryComIncludes()
        {
            return _context.Solicitacoes
                .Include(s => s.Cliente).ThenInclude(c => c!.TipoUsuario)
                .Include(s => s.Cliente).ThenInclude(c => c!.Enderecos).ThenInclude(ce => ce.Endereco)
                .Include(s => s.Endereco)
                .Include(s => s.EquipeColeta).ThenInclude(eq => eq!.Empresa)
                .Include(s => s.Catador).ThenInclude(c => c!.TipoUsuario)
                .Include(s => s.TiposMaterial);
        }

        public async Task<List<SolicitacaoResponseDto>> GetAllAsync()
        {
            var solicitacoes = await QueryComIncludes().ToListAsync();
            return _mapper.Map<List<SolicitacaoResponseDto>>(solicitacoes);
        }

        public async Task<SolicitacaoResponseDto> GetByIdAsync(int id)
        {
            var solicitacao = await QueryComIncludes()
                .FirstOrDefaultAsync(s => s.Id == id)
                ?? throw new NotFoundException($"Solicitação com id {id} não encontrada.");

            return _mapper.Map<SolicitacaoResponseDto>(solicitacao);
        }

        public async Task<List<SolicitacaoResponseDto>> GetByClienteAsync(int clienteId)
        {
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == clienteId);
            if (!clienteExiste)
                throw new NotFoundException($"Cliente com id {clienteId} não encontrado.");

            var solicitacoes = await QueryComIncludes()
                .Where(s => s.ClienteId == clienteId)
                .ToListAsync();

            return _mapper.Map<List<SolicitacaoResponseDto>>(solicitacoes);
        }

        public async Task<SolicitacaoResponseDto> CreateAsync(SolicitacaoRequestDto dto)
        {
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == dto.ClienteId);
            if (!clienteExiste)
                throw new NotFoundException($"Cliente com id {dto.ClienteId} não encontrado.");

            var enderecoExiste = await _context.Enderecos.AnyAsync(e => e.Id == dto.EnderecoId);
            if (!enderecoExiste)
                throw new NotFoundException($"Endereço com id {dto.EnderecoId} não encontrado.");

            var solicitacao = _mapper.Map<Models.Solicitacao>(dto);

            _context.Solicitacoes.Add(solicitacao);
            await _context.SaveChangesAsync();

            foreach (var material in dto.TiposMaterial)
            {
                _context.SolicitacoesTipoMaterial.Add(new SolicitacaoTipoMaterial
                {
                    SolicitacaoId = solicitacao.Id,
                    TipoMaterialId = material.TipoMaterialId,
                    Quantidade = material.Quantidade
                });
            }
            await _context.SaveChangesAsync();

            return await GetByIdAsync(solicitacao.Id);
        }

        public async Task<SolicitacaoResponseDto> UpdateStatusAsync(int id, SolicitacaoStatusUpdateDto dto)
        {
            var solicitacao = await _context.Solicitacoes.FindAsync(id)
                ?? throw new NotFoundException($"Solicitação com id {id} não encontrada.");

            if (solicitacao.Status == "concluída" || solicitacao.Status == "cancelada")
                throw new BusinessException("Não é possível alterar o status de uma solicitação concluída ou cancelada.");

            solicitacao.Status = dto.Status;
            await _context.SaveChangesAsync();

            return await GetByIdAsync(solicitacao.Id);
        }

        public async Task<SolicitacaoResponseDto> AtribuirEquipeAsync(int id, int equipeId)
        {
            var solicitacao = await _context.Solicitacoes.FindAsync(id)
                ?? throw new NotFoundException($"Solicitação com id {id} não encontrada.");

            var equipe = await _context.EquipesColeta.FindAsync(equipeId)
                ?? throw new NotFoundException($"Equipe com id {equipeId} não encontrada.");

            if (equipe.Status != "ativa")
                throw new BusinessException("Apenas equipes ativas podem ser atribuídas a uma solicitação.");

            solicitacao.EquipeColetaId = equipeId;
            solicitacao.Status = "em andamento";
            await _context.SaveChangesAsync();

            return await GetByIdAsync(solicitacao.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var solicitacao = await _context.Solicitacoes.FindAsync(id)
                ?? throw new NotFoundException($"Solicitação com id {id} não encontrada.");

            if (solicitacao.Status == "em andamento" || solicitacao.Status == "concluída")
                throw new BusinessException("Não é possível excluir uma solicitação em andamento ou concluída.");

            _context.Solicitacoes.Remove(solicitacao);
            await _context.SaveChangesAsync();
        }
    }
}