using Microsoft.AspNetCore.Mvc;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.Services;
using PSI.TI.GestaoEscolar.Application.ViewModels;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.MVC.Controllers
{
    public class DisciplinasController : BaseController
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinasController(INotificador notificador,
            IDisciplinaService disciplinaService) : base(notificador)
        {
            _disciplinaService = disciplinaService;
        }

        [Route("disciplinas")]
        public async Task<IActionResult> Index()
        {
            var disciplinas = await _disciplinaService.ObterTodas();

            if (disciplinas == null) return NotFound();

            return View(disciplinas);
        }

        [Route("obter-disciplinas")]
        public async Task<IActionResult> ObterDisciplinas()
        {
            var disciplinas = await _disciplinaService.ObterTodas();

            if (disciplinas == null) return NotFound();

            return PartialView("_ListaDisciplinas", disciplinas);
        }

        [Route("cadastrar-disciplina")]
        public IActionResult Cadastrar()
        {
            return PartialView("_Cadastro", new DisciplinaViewModel());
        }

        [HttpPost]
        [Route("cadastrar-disciplina")]
        public async Task<IActionResult> Cadastrar(DisciplinaViewModel disciplinaViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_Cadastro", disciplinaViewModel);

            await _disciplinaService.Adicionar(disciplinaViewModel);

            if (!OperacaoValida) return PartialView("_Cadastro", disciplinaViewModel);

            TempData["Sucesso"] = "Disciplina cadastrada com sucesso!";

            var url = Url.Action("ObterDisciplinas", "Disciplinas");
            return Json(new { success = true, url });
        }
    }
}