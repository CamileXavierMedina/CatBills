using System;
using System.ComponentModel.DataAnnotations;

namespace CatBills.DTOs
{
    public class CriarDespesaDto
    {
        [Required]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser superior a zero.")]
        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }

        [Required]
        public string MeioPagamento { get; set; } = "DEBITO";

        [Required]
        public string TipoDespesa { get; set; } = "VARIAVEL";

        public int CategoriaId { get; set; }
    }
}
