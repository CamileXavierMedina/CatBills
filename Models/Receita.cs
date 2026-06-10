using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatBills.Models
{
    [Table("receitas")]
    public class Receita
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("origem")]
        public string Origem { get; set; } = "Geral"; // Ex: Freelance, Salário, Investimento
    }
}