using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Dtos.Autenticacao;
using project_api_reciclaAi.Exceptions;
using project_api_reciclaAi.Models;
using System.Security.Cryptography;
using System.Text;

namespace project_api_reciclaAi.Services.Autenticacao
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly ReciclaAIContext _context;

        public AutenticacaoService(ReciclaAIContext context)
        {
            _context = context;
        }

        public async Task<GerarChaveResponseDto> GerarChaveAsync(GerarChaveRequestDto dto)
        {
            var email = dto.Email.Trim();
            var usuario = await _context.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
                throw new UnauthorizedException("E-mail não encontrado.");

            if (!usuario.Ativo)
                throw new UnauthorizedException("Usuário inativo.");

            var chave = GerarChave();
            var expiraEm = DateTime.UtcNow.AddHours(12);
            var perfil = usuario.Perfil.Trim().ToLowerInvariant();

            var chaveAutenticacao = new ChaveAutenticacao
            {
                ChaveHash = GerarHash(chave),
                UsuarioTipo = perfil,
                UsuarioId = usuario.Id,
                CriadoEm = DateTime.UtcNow,
                ExpiraEm = expiraEm
            };

            _context.ChaveAutenticacao.Add(chaveAutenticacao);
            await _context.SaveChangesAsync();

            return new GerarChaveResponseDto
            {
                ChaveAutenticacao = chave,
                Perfil = usuario.Perfil,
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                ExpiraEm = expiraEm
            };
        }

        public static string GerarHash(string chave)
        {
            var bytes = Encoding.UTF8.GetBytes(chave);
            var hash = SHA256.HashData(bytes);
            return Convert.ToHexString(hash);
        }

        private static string GerarChave()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .TrimEnd('=');
        }

    }
}
