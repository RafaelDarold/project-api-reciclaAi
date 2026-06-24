using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.TipoUsuario;
using project_api_reciclaAi.Exceptions;

namespace project_api_reciclaAi.Services.TipoUsuario
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public TipoUsuarioService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponseDto<TipoUsuarioResponseDto>> GetAllAsync(PaginationQueryDto pagination)
        {
            return await _context.TipoUsuario
                .ToPaginatedResponseAsync<Models.TipoUsuario, TipoUsuarioResponseDto>(pagination, _mapper);
        }

        public async Task<TipoUsuarioResponseDto> GetByIdAsync(int id)
        {
            var tipo = await _context.TipoUsuario.FindAsync(id)
                ?? throw new NotFoundException($"Tipo de usuário com id {id} não encontrado.");

            return _mapper.Map<TipoUsuarioResponseDto>(tipo);
        }
    }
}