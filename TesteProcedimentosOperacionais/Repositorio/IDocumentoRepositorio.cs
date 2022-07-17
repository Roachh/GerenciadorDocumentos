using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
    public interface IDocumentoRepositorio
    {
        List<DocumentoModel> BuscarDocumentos();
        DocumentoModel Adicionar(DocumentoModel documento);
		
	}
}
