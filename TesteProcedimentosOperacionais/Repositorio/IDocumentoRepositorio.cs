using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
    public interface IDocumentoRepositorio
    {
        List<DocumentoModel> BuscarTodos();
        DocumentoModel Adicionar(DocumentoModel documento);

    }
}
