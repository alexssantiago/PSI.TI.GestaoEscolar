using System.Collections.Generic;
using System.Linq;

namespace PSI.TI.GestaoEscolar.Application.Notification
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public bool PossuiNotificacoes() => _notificacoes.Any();

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }
    }
}