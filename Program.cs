using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.DataContexts;
using project_api_reciclaAi.Middlewares;
using project_api_reciclaAi.Services.TipoUsuario;
using project_api_reciclaAi.Services.TipoMaterial;
using project_api_reciclaAi.Services.Empresa;
using project_api_reciclaAi.Services.EquipeColeta;
using project_api_reciclaAi.Services.Cliente;
using project_api_reciclaAi.Services.Catador;
using project_api_reciclaAi.Services.Solicitacao;
using project_api_reciclaAi.Services.Coleta;
using project_api_reciclaAi.Services.Avaliacao;
using project_api_reciclaAi.Services.Autenticacao;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ReciclaAIContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<ITipoMaterialService, TipoMaterialService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEquipeColetaService, EquipeColetaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICatadorService, CatadorService>();
builder.Services.AddScoped<ISolicitacaoService, SolicitacaoService>();
builder.Services.AddScoped<IColetaService, ColetaService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(ApiKeyMiddleware.HeaderName, new OpenApiSecurityScheme
    {
        Description = $"Informe a chave gerada pelo endpoint /autenticacao/gerar-chave no header {ApiKeyMiddleware.HeaderName}.",
        Name = ApiKeyMiddleware.HeaderName,
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = ApiKeyMiddleware.HeaderName
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = ApiKeyMiddleware.HeaderName
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
