using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatBills.Models
{
    [Table("categorias_despesas")]
    public class CategoriaDespesa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("cor_hex")]
        public string CorHex { get; set; } = "#FFFFFF";
    }
}