using Microsoft.AspNetCore.Mvc;

namespace PSI.TI.GestaoEscolar.MVC.Controllers
{
    public class AlunosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
