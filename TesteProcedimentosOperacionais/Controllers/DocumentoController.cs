using Microsoft.AspNetCore.Mvc;
using TesteProcedimentosOperacionais.Models;
using TesteProcedimentosOperacionais.Repositorio;

namespace TesteProcedimentosOperacionais.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IDocumentoRepositorio _documentoRepositorio;
        public DocumentoController(IDocumentoRepositorio documentoRepositorio)
        {
            _documentoRepositorio = documentoRepositorio;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Consultar()
        {            
            List<DocumentoModel> documentos = _documentoRepositorio.BuscarTodos();         
            return View(documentos);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([Bind("Codigo, Titulo, Categoria, Processo, Arquivo")] DocumentoModel documento)
        {
            var arquivo = documento.Arquivo;            
            if (arquivo != null && arquivo.Length > 0)
            {                
                var nomeDoArquivo = Guid.NewGuid() + Path.GetFileName(arquivo.FileName);
                var pathAbsoluto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arquivos", nomeDoArquivo);
            var pathRelativo = "/arquivos/" + nomeDoArquivo;
            documento.ArquivoPathRel = pathRelativo;                

                if (ModelState.IsValid)
                {
                    using (var fileStream = new FileStream(pathAbsoluto, FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                    }
                    _documentoRepositorio.Adicionar(documento);

                    return RedirectToAction("Consultar");
                }           
            }

            return View(documento);
        }
    }
}
