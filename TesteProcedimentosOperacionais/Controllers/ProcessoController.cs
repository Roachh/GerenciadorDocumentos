using Microsoft.AspNetCore.Mvc;
using TesteProcedimentosOperacionais.Models;
using TesteProcedimentosOperacionais.Repositorio;

namespace TesteProcedimentosOperacionais.Controllers
{
    public class ProcessoController : Controller
    {
        private readonly IProcessoRepositorio _processoRepositorio;

        public ProcessoController(IProcessoRepositorio processoRepositorio)
        {
            _processoRepositorio = processoRepositorio;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
