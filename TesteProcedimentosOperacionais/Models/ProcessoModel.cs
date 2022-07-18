using System.ComponentModel.DataAnnotations;

namespace TesteProcedimentosOperacionais.Models
{
	public class Processo
	{
		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }
	}
}
