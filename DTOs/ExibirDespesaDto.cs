using System;

namespace CatBills.DTOs
{
    public class ExibirDespesaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }
        public string MeioPagamento { get; set; } = string.Empty;
        public string TipoDespesa { get; set; } = string.Empty;
        public string NomeCategoria { get; set; } = string.Empty;
    }
}