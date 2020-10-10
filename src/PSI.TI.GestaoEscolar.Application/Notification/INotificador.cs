using System.Collections.Generic;

namespace PSI.TI.GestaoEscolar.Application.Notification
{
    public interface INotificador
    {
        bool PossuiNotificacoes();
        IReadOnlyCollection<Notificacao> Notificacoes { get; }
        void Handle(Notificacao notificacao);
    }
}