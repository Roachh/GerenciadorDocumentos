using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
	public interface IProcessoRepositorio
	{
		List<Processo> BuscarProcessos();
	}
}
