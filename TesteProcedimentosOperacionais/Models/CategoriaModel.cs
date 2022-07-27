using System.ComponentModel.DataAnnotations;

namespace TesteProcedimentosOperacionais.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProcessoId { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
