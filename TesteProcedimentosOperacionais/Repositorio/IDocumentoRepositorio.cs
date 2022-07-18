using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
    public interface IDocumentoRepositorio
    {
        List<Documento> BuscarDocumentos();
        Documento Adicionar(Documento documento);
    }
}
