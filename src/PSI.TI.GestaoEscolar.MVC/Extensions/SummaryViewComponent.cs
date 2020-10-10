using Microsoft.AspNetCore.Mvc;
using PSI.TI.GestaoEscolar.Application.Notification;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.Notificacoes);

            foreach (var notificacao in notificacoes)
                ViewData.ModelState.AddModelError(string.Empty, notificacao.Mensagem);

            return View();
        }
    }
}