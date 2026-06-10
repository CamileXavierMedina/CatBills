using System;

namespace CatBills.DTOs
{
    public class ExibirReceitaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Origem { get; set; } = string.Empty;
    }
}
