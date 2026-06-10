using System;
using System.ComponentModel.DataAnnotations;

namespace CatBills.DTOs
{
    public class CriarReceitaDto
    {
        [Required]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser superior a zero.")]
        public decimal Valor { get; set; }

        public DateTime Data { get; set; }
        public string Origem { get; set; } = string.Empty;
    }
}