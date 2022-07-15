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
        public IActionResult Consulta()
        {            
            List<DocumentoModel> documentos = _documentoRepositorio.BuscarTodos();         
            return View(documentos);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(DocumentoModel documento, IFormFile file)
        {
            Console.WriteLine("documento: " + documento.Titulo);
            Console.WriteLine("file: " + file);

            if (file != null && file.Length > 0)
            {              
                var fileName = Path.GetFileName(file.FileName);
                fileName = string.Format(fileName, Guid.NewGuid());
                var absoluteFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arquivos", fileName);
                var relativeFilePath = "/arquivos/" + fileName;
                documento.Arquivo = relativeFilePath;

                using (var fileStream = new FileStream(absoluteFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                _documentoRepositorio.Adicionar(documento);    
            }
            return RedirectToAction("Cadastrar");
        }
    }
}
