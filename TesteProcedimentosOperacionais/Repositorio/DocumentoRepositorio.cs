using TesteProcedimentosOperacionais.Data;
using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Repositorio
{
    public class DocumentoRepositorio : IDocumentoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public DocumentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<DocumentoModel> BuscarTodos()
        {
            return _bancoContext.Documentos.ToList();
        }
        public DocumentoModel Adicionar(DocumentoModel documento)
        {
            // gravar no banco de dados
            _bancoContext.Documentos.Add(documento);
            _bancoContext.SaveChanges();

            return documento;
        }

       
    }
}
