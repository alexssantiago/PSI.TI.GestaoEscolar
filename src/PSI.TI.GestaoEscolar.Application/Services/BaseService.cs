using FluentValidation;
using FluentValidation.Results;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public class BaseService
    {
        private readonly INotificador _notificator;

        public BaseService(INotificador notificator)
        {
            _notificator = notificator;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notificar(error.ErrorMessage);
        }

        protected void Notificar(string mensagem)
        {
            _notificator.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TValidation, TEntity>(TValidation validacao, TEntity entidade)
            where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}