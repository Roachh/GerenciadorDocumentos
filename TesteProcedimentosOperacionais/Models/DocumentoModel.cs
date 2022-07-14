using System.ComponentModel.DataAnnotations;

namespace TesteProcedimentosOperacionais.Models
{
    public class DocumentoModel
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Processo { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Arquivo { get; set; }
    }
}
