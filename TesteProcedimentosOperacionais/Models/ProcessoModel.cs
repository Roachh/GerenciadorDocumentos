using System.ComponentModel.DataAnnotations;

namespace TesteProcedimentosOperacionais.Models
{
	public class ProcessoModel
	{
		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }
	}
}
