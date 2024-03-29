﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteProcedimentosOperacionais.Utilities;

namespace TesteProcedimentosOperacionais.Models
{
    public class Documento
    {
        [Key]
        [CodigoUnico]
        [Required(ErrorMessage = "Digite o código do documento.")]
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Digite o título do documento.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Selecione o processo do documento.")]
        public int ProcessoId { get; set; }

        public Processo? Processo { get; set; }

        [Required(ErrorMessage = "Selecione a categoria do documento.")]
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        [Column("Arquivo")]
        public string? NomeArquivo { get; set; }

        [NotMapped]
        [FormatoValido(ErrorMessage = "Selecione um arquivo com extensão válida.")]
        [Required(ErrorMessage = "Selecione o arquivo.")]
        public IFormFile Arquivo { get; set; }
    }
}
