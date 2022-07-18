using TesteProcedimentosOperacionais.Data;
using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
	public class ProcessoRepositorio : IProcessoRepositorio
	{
		private readonly BancoContext _bancoContext;
		public ProcessoRepositorio(BancoContext bancoContext)
		{
			_bancoContext = bancoContext;
		}
		public List<Processo> BuscarProcessos()
		{
			return _bancoContext.Processos.ToList();
		}
	}
}
