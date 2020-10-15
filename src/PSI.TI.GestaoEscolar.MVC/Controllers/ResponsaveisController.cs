using Microsoft.AspNetCore.Mvc;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.Services;
using PSI.TI.GestaoEscolar.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.MVC.Controllers
{
    public class ResponsaveisController : BaseController
    {
        private readonly IResponsavelService _responsavelService;

        public ResponsaveisController(INotificador notificador,
            IResponsavelService responsavelService) : base(notificador)
        {
            _responsavelService = responsavelService;
        }

        [Route("responsaveis")]
        public async Task<IActionResult> Index()
        {
            var responsaveis = await _responsavelService.ObterTodos();

            if (responsaveis == null) return NotFound();

            return View(responsaveis);
        }

        [Route("obter-responsaveis")]
        public async Task<IActionResult> ObterResponsaveis()
        {
            var responsaveis = await _responsavelService.ObterTodos();

            if (responsaveis == null) return NotFound();

            return PartialView("_ListaResponsaveis", responsaveis);
        }

        [Route("responsavel/{id:guid}")]
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var responsavel = await _responsavelService.ObterResponsavelDependentesPorId(id);

            if (responsavel == null) return NotFound();

            return View(responsavel);
        }

        [Route("cadastro-responsavel")]
        public IActionResult Cadastrar()
        {
            return PartialView("_Cadastro", new ResponsavelViewModel());
        }

        [HttpPost]
        [Route("cadastro-responsavel")]
        public async Task<IActionResult> Cadastrar(ResponsavelViewModel responsavelViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_Cadastro", responsavelViewModel);

            await _responsavelService.Adicionar(responsavelViewModel);

            if (!OperacaoValida) return PartialView("_Cadastro", responsavelViewModel);

            TempData["Sucesso"] = "Responsável cadastrado com sucesso!";

            var url = Url.Action("ObterResponsaveis", "Responsaveis");
            return Json(new { success = true, url });
        }

        [Route("editar-responsavel/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var responsavel = await _responsavelService.ObterPorId(id);

            if (responsavel == null) return NotFound();

            return PartialView("_Editar", responsavel);
        }

        [HttpPost]
        [Route("editar-responsavel/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id, ResponsavelViewModel responsavelViewModel)
        {
            if (id != responsavelViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return PartialView("_Editar", responsavelViewModel);

            await _responsavelService.Atualizar(responsavelViewModel);

            if (!OperacaoValida) return PartialView("_Editar", responsavelViewModel);

            TempData["Sucesso"] = "Responsável atualizado com sucesso!";

            var url = Url.Action("ObterResponsaveis", "Responsaveis");
            return Json(new { success = true, url });
        }

        [Route("adicionar-dependente-responsavel/{responsavelId:guid}")]
        public IActionResult AdicionarDependente(Guid responsavelId)
        {
            return PartialView("_CadastroDependente", new AlunoViewModel { ResponsavelId = responsavelId });
        }

        [HttpPost]
        [Route("adicionar-dependente-responsavel/{responsavelId:guid}")]
        public async Task<IActionResult> AdicionarDependente(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_CadastroDependente", alunoViewModel);

            await _responsavelService.AdicionarDependente(alunoViewModel);

            if (!OperacaoValida) return PartialView("_CadastroDependente", alunoViewModel);

            TempData["Sucesso"] = "Dependente cadastrado com sucesso!";

            var url = Url.Action("ObterDependentes", "Responsaveis", new { id = alunoViewModel.ResponsavelId });
            return Json(new { success = true, url });
        }

        [Route("obter-dependentes-responsavel/{id:guid}")]
        public async Task<IActionResult> ObterDependentes(Guid id)
        {
            var responsavel = await _responsavelService.ObterResponsavelDependentesPorId(id);

            if (responsavel == null) return NotFound();

            return PartialView("_ListaDependentes", responsavel.Dependentes);
        }
    }
}