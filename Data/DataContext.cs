using Microsoft.EntityFrameworkCore;
using CatBills.Models;
using System.Linq;

namespace CatBills.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Utilizador> Utilizadores { get; set; } = null!;
        public DbSet<CategoriaDespesa> Categorias { get; set; } = null!;
        public DbSet<Despesa> Despesas { get; set; } = null!;
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

            if (!context.Utilizadores.Any())
            {
                context.Utilizadores.Add(new Utilizador
                {
                    Nome = "Estudante Programador",
                    Email = "estudante@ipt.pt",
                    SalarioMensal = 2500.00m
                });
                context.SaveChanges();
            }
        }
    }
}