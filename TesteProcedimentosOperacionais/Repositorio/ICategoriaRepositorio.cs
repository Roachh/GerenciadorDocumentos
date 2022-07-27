using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
    public interface ICategoriaRepositorio
    {
        List<Categoria> BuscarCategorias(int ProcessoId);
    }
}
