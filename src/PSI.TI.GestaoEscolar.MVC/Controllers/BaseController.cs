using Microsoft.AspNetCore.Mvc;
using PSI.TI.GestaoEscolar.Application.Notification;

namespace PSI.TI.GestaoEscolar.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida => !_notificador.PossuiNotificacoes();
    }
}