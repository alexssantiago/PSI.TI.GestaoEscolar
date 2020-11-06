using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.Services;
using PSI.TI.GestaoEscolar.Application.ViewModels;

namespace PSI.TI.GestaoEscolar.MVC.Controllers
{
    public class DependentesController : BaseController
    {
        private readonly IResponsavelService _responsavelService;
        private readonly IAlunoService _alunoService;

        public DependentesController(INotificador notificador,
            IResponsavelService responsavelService,
            IAlunoService alunoService) : base(notificador)
        {
            _responsavelService = responsavelService;
            _alunoService = alunoService;
        }


        [Route("obter-dependentes/{responsavelId:guid}")]
        public async Task<IActionResult> ObterDependentes(Guid responsavelId)
        {
            var responsavel = await _responsavelService.ObterResponsavelDependentesPorId(responsavelId);

            if (responsavel == null) return NotFound();

            return PartialView("_ListaDependentes", responsavel.Dependentes);
        }

        [Route("cadastrar-dependente/{responsavelId:guid}")]
        public IActionResult Cadastrar(Guid responsavelId)
        {
            return PartialView("_CadastroDependente", new AlunoViewModel { ResponsavelId = responsavelId });
        }

        [HttpPost]
        [Route("cadastrar-dependente/{responsavelId:guid}")]
        public async Task<IActionResult> Cadastrar([FromForm] AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid) return PartialView("_CadastroDependente", alunoViewModel);

            await _responsavelService.AdicionarDependente(alunoViewModel);

            if (!OperacaoValida) return PartialView("_CadastroDependente", alunoViewModel);

            TempData["Sucesso"] = "Dependente cadastrado com sucesso!";

            var url = Url.Action("ObterDependentes", new { responsavelId = alunoViewModel.ResponsavelId });
            return Json(new { success = true, url });
        }

        [Route("atualizar-dependente/{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var dependente = await _alunoService.ObterPorId(id);

            if (dependente == null) return NotFound();

            return PartialView("_Atualizar", dependente);
        }

        [HttpPost]
        [Route("atualizar-dependente/{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return PartialView("_Atualizar", alunoViewModel);

            await _responsavelService.AtualizarDependente(alunoViewModel);

            if (!OperacaoValida) return PartialView("_Atualizar", alunoViewModel);

            TempData["Sucesso"] = "Dependente atualizado com sucesso!";

            var url = Url.Action("ObterDependentes", new { responsavelId = alunoViewModel.ResponsavelId });
            return Json(new { success = true, url });
        }
    }
}