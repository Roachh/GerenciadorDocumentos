using Microsoft.AspNetCore.Mvc;

namespace TesteProcedimentosOperacionais.Controllers
{
    public class DocumentoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();

        }
        public IActionResult Consulta()
        {
            return View();
        }
    }
}
