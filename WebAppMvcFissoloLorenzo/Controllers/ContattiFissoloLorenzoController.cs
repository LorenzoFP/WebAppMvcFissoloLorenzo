using Microsoft.AspNetCore.Mvc;

namespace WebAppMvcFissoloLorenzo.Controllers
{
    public class ContattiFissoloLorenzoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Conteggio()
        {
            ViewData["Conteggio"] = "VerificaFissoloLorenzo";
            return View();
        }
    }
}
