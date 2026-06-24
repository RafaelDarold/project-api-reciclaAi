using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Services.Autenticacao;
using System.Text.Json;

namespace project_api_reciclaAi.Middlewares
{
    public class ApiKeyMiddleware
    {
        public const string HeaderName = "X-API-KEY";

        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public ApiKeyMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (EhRotaPublica(context.Request))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(HeaderName, out var valores) ||
                string.IsNullOrWhiteSpace(valores.FirstOrDefault()))
            {
                await EscreverNaoAutorizadoAsync(context, $"Informe a chave de autenticação no header '{HeaderName}'.");
                return;
            }

            var chave = valores.First()!;
            var chaveHash = AutenticacaoService.GerarHash(chave);

            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ReciclaAIContext>();

            var chaveAutenticacao = await dbContext.ChaveAutenticacao
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ChaveHash == chaveHash);

            if (chaveAutenticacao == null ||
                chaveAutenticacao.RevogadaEm != null ||
                chaveAutenticacao.ExpiraEm <= DateTime.UtcNow)
            {
                await EscreverNaoAutorizadoAsync(context, "Chave de autenticação inválida ou expirada.");
                return;
            }

            var usuarioAtivo = await dbContext.Usuario
                .AsNoTracking()
                .AnyAsync(u => u.Id == chaveAutenticacao.UsuarioId &&
                               u.Ativo &&
                               u.Perfil.ToLower() == chaveAutenticacao.UsuarioTipo);

            if (!usuarioAtivo)
            {
                await EscreverNaoAutorizadoAsync(context, "Usuário da chave não encontrado ou inativo.");
                return;
            }

            context.Items["UsuarioPerfil"] = chaveAutenticacao.UsuarioTipo;
            context.Items["UsuarioId"] = chaveAutenticacao.UsuarioId;

            await _next(context);
        }

        private static bool EhRotaPublica(HttpRequest request)
        {
            if (HttpMethods.IsOptions(request.Method))
                return true;

            var path = request.Path;
            return path == "/v1" ||
                   path.StartsWithSegments("/v1/autenticacao") ||
                   path.StartsWithSegments("/swagger");
        }

        private static Task EscreverNaoAutorizadoAsync(HttpContext context, string mensagem)
        {
            var response = new
            {
                statusCode = StatusCodes.Status401Unauthorized,
                message = mensagem,
                timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
