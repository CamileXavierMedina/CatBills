using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CatBills.Data;

var builder = WebApplication.CreateBuilder(args);

// ============================================================================
// CONFIGURAÇÃO DOS SERVIÇOS (DI & INFRAESTRUTURA)
// ============================================================================

// 1. Configuração do SQLite local unificado
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=catbills.db"));

// 2. CONFIGURAÇÃO DE SEGURANÇA (CORS): Libera o acesso para o seu HTML em qualquer outra porta
builder.Services.AddCors(options =>
{
    options.AddPolicy("LiberarGeral", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 3. Controladores e Prevenção de Loops de Referência JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();

// 4. Documentação Swagger com Resolução de Conflito de Rotas
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// ============================================================================
// CONFIGURAÇÃO DO PIPELINE DE EXECUÇÃO (MIDDLEWARES)
// ============================================================================

app.UseCors("LiberarGeral");

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// 5. Carga Inicial do Banco de Dados (Seed)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
    DbSeeder.Seed(context);
}

// INICIALIZAÇÃO NATIVA: O Visual Studio define a porta dinamicamente ao clicar no Play
app.Run();