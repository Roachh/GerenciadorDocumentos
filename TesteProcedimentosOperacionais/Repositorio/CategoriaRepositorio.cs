using TesteProcedimentosOperacionais.Data;
using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public CategoriaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<Categoria> BuscarCategorias(int ProcessoId)
        {
            return _bancoContext.Categorias.Where(x => x.ProcessoId == ProcessoId).ToList();
        }
    }
}
