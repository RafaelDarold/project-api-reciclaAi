using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.Cliente;
using project_api_reciclaAi.Exceptions;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly ReciclaAIContext _context;
        private readonly IMapper _mapper;

        public ClienteService(ReciclaAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClienteResponseDto>> GetAllAsync()
        {
            var clientes = await _context.Cliente
                .Include(c => c.TipoUsuario)
                .Include(c => c.Endereco)
                    .ThenInclude(ce => ce.Endereco)
                .ToListAsync();

            return _mapper.Map<List<ClienteResponseDto>>(clientes);
        }

        public async Task<ClienteResponseDto> GetByIdAsync(int id)
        {
            var cliente = await _context.Cliente
                .Include(c => c.TipoUsuario)
                .Include(c => c.Endereco)
                    .ThenInclude(ce => ce.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new NotFoundException($"Cliente com id {id} não encontrado.");

            return _mapper.Map<ClienteResponseDto>(cliente);
        }

        public async Task<ClienteResponseDto> CreateAsync(ClienteRequestDto dto)
        {
            var emailExiste = await _context.Cliente
                .AnyAsync(c => c.Email == dto.Email);
            if (emailExiste)
                throw new ConflictException("Já existe um cliente cadastrado com este e-mail.");

            var cpfCnpjExiste = await _context.Cliente
                .AnyAsync(c => c.CpfCnpj == dto.CpfCnpj);
            if (cpfCnpjExiste)
                throw new ConflictException("Já existe um cliente cadastrado com este CPF/CNPJ.");

            var cliente = _mapper.Map<Models.Cliente>(dto);
            cliente.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            var endereco = _mapper.Map<Endereco>(dto.Endereco);
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            _context.ClienteEndereco.Add(new ClienteEndereco
            {
                ClienteId = cliente.Id,
                EnderecoId = endereco.Id
            });
            await _context.SaveChangesAsync();

            return await GetByIdAsync(cliente.Id);
        }

        public async Task<ClienteResponseDto> UpdateAsync(int id, ClienteUpdateDto dto)
        {
            var cliente = await _context.Cliente.FindAsync(id)
                ?? throw new NotFoundException($"Cliente com id {id} não encontrado.");

            if (dto.Email != null && dto.Email != cliente.Email)
            {
                var emailExiste = await _context.Cliente
                    .AnyAsync(c => c.Email == dto.Email);
                if (emailExiste)
                    throw new ConflictException("Já existe um cliente cadastrado com este e-mail.");
            }

            _mapper.Map(dto, cliente);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(cliente.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id)
                ?? throw new NotFoundException($"Cliente com id {id} não encontrado.");

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}