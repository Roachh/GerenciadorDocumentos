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
            return RedirectToAction("Cadastro");
        }

        public IActionResult Cadastro()
        {
            return View();

        }
        public IActionResult Consulta()
        {
            List<DocumentoModel> documentos = _documentoRepositorio.BuscarTodos();
            return View(documentos);
        }

        [HttpPost]
        public IActionResult Cadastrar(DocumentoModel documento)
        {
            _documentoRepositorio.Adicionar(documento);
            return RedirectToAction("Cadastro");
        }
    }
}
