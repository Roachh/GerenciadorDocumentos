using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteProcedimentosOperacionais.Models
{
    public class DocumentoModel
    {
        [Key]
        [Required(ErrorMessage = "Digite o código do documento.")]
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Digite o título do documento.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Selecione o processo do documento.")]
        public int ProcessoId { get; set; }
        [Required(ErrorMessage = "Selecione a categoria do documento.")]
        public string Categoria { get; set; }

        [Column("Arquivo")]
        public string? ArquivoPathRel { get; set; }

        //validação?
        [NotMapped]
        [Required(ErrorMessage = "Selecione o arquivo.")]
        public IFormFile Arquivo { get; set; }
    }
}
