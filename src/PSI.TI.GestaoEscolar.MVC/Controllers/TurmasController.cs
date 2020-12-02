using System;
using Microsoft.AspNetCore.Mvc;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.Services;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.MVC.Controllers
{
    public class TurmasController : BaseController
    {
        private readonly ITurmaService _turmaService;

        public TurmasController(INotificador notificador, 
            ITurmaService turmaService) : base(notificador)
        {
            _turmaService = turmaService;
        }

        [Route("turmas")]
        public async Task<IActionResult> Index()
        {
            var turmas = await _turmaService.ObterTodas();

            if (turmas == null) return NotFound();

            return View(turmas);
        }

        [Route("detalhes-turma/{id:guid}")]
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var turma = await _turmaService.ObterPorId(id);

            if (turma == null) return NotFound();

            return View(turma);
        }
    }
}