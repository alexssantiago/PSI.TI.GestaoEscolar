using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.Services;
using PSI.TI.GestaoEscolar.Application.ViewModels;

namespace PSI.TI.GestaoEscolar.MVC.Controllers
{
    public class ProfessoresController : BaseController
    {
        private readonly IProfessorService _professorService;

        public ProfessoresController(INotificador notificador,
            IProfessorService professorService) : base(notificador)
        {
            _professorService = professorService;
        }

        [Route("professores")]
        public async Task<IActionResult> Index()
        {
            var professores = await _professorService.ObterTodos();

            if (professores == null) return NotFound();

            return View(professores);
        }

        [Route("obter-professores")]
        public async Task<IActionResult> ObterProfessores()
        {
            var professores = await _professorService.ObterTodos();

            if (professores == null) return NotFound();

            return PartialView("_ListaProfessores", professores);
        }

        [Route("cadastrar-professor")]
        public IActionResult Cadastrar()
        {
            return PartialView("_Cadastro", new ProfessorViewModel());
        }

        [HttpPost]
        [Route("cadastrar-professor")]
        public async Task<IActionResult> Cadastrar(ProfessorViewModel professorViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_Cadastro", professorViewModel);

            await _professorService.Adicionar(professorViewModel);

            if (!OperacaoValida) return PartialView("_Cadastro", professorViewModel);

            TempData["Sucesso"] = "Professor cadastrado com sucesso!";

            var url = Url.Action("ObterProfessores", "Professores");
            return Json(new {success = true, url});
        }
    }
}