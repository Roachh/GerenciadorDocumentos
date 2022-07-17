using Microsoft.AspNetCore.Mvc;
using TesteProcedimentosOperacionais.Models;
using TesteProcedimentosOperacionais.Repositorio;

namespace TesteProcedimentosOperacionais.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IDocumentoRepositorio _documentoRepositorio;
        private readonly IProcessoRepositorio _processoRepositorio;

        public DocumentoController(IDocumentoRepositorio documentoRepositorio, IProcessoRepositorio processoRepositorio)
        {
            _documentoRepositorio = documentoRepositorio;
            _processoRepositorio = processoRepositorio;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Cadastrar()
        {
            List<ProcessoModel> processos = _processoRepositorio.BuscarProcessos();
            ViewBag.Processos = processos;
            return View();
        }
        public IActionResult Consultar()
        {
            List<DocumentoModel> documentos = _documentoRepositorio.BuscarDocumentos();
            ViewBag.Documentos = documentos;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([Bind("Codigo, Titulo, Categoria, ProcessoId, Arquivo")] DocumentoModel documento)
        {
            try
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
                        TempData["MensagemSucesso"] = "Documento adicionado com sucesso";

                        return RedirectToAction("Consultar");
                    }
                }

                List<ProcessoModel> processos = _processoRepositorio.BuscarProcessos();
                ViewBag.Processos = processos;
                return View(documento);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar o documento, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }
        }
    }
}
