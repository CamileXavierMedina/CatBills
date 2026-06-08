using System.ComponentModel.DataAnnotations;

namespace CatBills.DTOs
{
    public class CriarUtilizadorDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public decimal SalarioMensal { get; set; }
    }
}