using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatBills.Models
{
    [Table("despesas")]
    public class Despesa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("data_vencimento")]
        public DateTime DataVencimento { get; set; }

        [Column("pago")]
        public bool Pago { get; set; }

        [Required]
        [Column("meio_pagamento")]
        public string MeioPagamento { get; set; } = "DEBITO"; // CREDITO, DEBITO, PIX

        [Required]
        [Column("tipo_despesa")]
        public string TipoDespesa { get; set; } = "VARIAVEL"; // FIXA, VARIAVEL

        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        [ForeignKey("CategoriaId")]
        public CategoriaDespesa? Categoria { get; set; }
    }
}