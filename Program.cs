using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CatBills.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=catbills.db"));

// 2. Controladores e Prevenção de Loops Infinitos de Referência JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();

// 3. Documentação Swagger com Resolução de Conflitos de Rotas
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// 4. Ativar o carregamento automático do index.html na pasta wwwroot
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

app.Run();
