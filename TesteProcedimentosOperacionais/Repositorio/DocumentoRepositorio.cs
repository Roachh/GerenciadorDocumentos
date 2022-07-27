using Microsoft.EntityFrameworkCore;
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
        public List<Documento> BuscarDocumentos()
        {            
            return _bancoContext.Documentos
                .Include(x => x.Processo)
                .Include(x => x.Categoria)
                .ToList();
        }
        public Documento Adicionar(Documento documento)
        {
            _bancoContext.Documentos.Add(documento);
            _bancoContext.SaveChanges();

            return documento;
        }		
	}
}
