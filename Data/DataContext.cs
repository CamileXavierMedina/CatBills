using Microsoft.EntityFrameworkCore;
using CatBills.Models;
using System.Linq;
using System;

namespace CatBills.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CategoriaDespesa> Categorias { get; set; } = null!;
        public DbSet<Despesa> Despesas { get; set; } = null!;
        public DbSet<Receita> Receitas { get; set; } = null!;
    }

    public static class DbSeeder
    {
        public static void Seed(DataContext context)
        {
            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(
                    new CategoriaDespesa { Nome = "Habitação", CorHex = "#FF5733" },
                    new CategoriaDespesa { Nome = "Alimentação", CorHex = "#33FF57" },
                    new CategoriaDespesa { Nome = "Transportes", CorHex = "#3357FF" },
                    new CategoriaDespesa { Nome = "Lazer", CorHex = "#F333FF" }
                );
                context.SaveChanges();
            }

            if (!context.Receitas.Any())
            {
                context.Receitas.AddRange(
                    new Receita { Descricao = "Salário Principal", Valor = 2500.00m, Data = DateTime.UtcNow, Origem = "Empresa" },
                    new Receita { Descricao = "Trabalho Freelance C#", Valor = 450.00m, Data = DateTime.UtcNow.AddDays(-2), Origem = "Freelance" }
                );
                context.SaveChanges();
            }
        }
    }
}
