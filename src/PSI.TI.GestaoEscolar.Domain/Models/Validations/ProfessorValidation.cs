using FluentValidation;

namespace PSI.TI.GestaoEscolar.Domain.Models.Validations
{
    public class ProfessorValidation : AbstractValidator<Professor>
    {
        public ProfessorValidation()
        {
            Include(new PessoaValidation());

            RuleFor(r => r.Formacao)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido.");
        }
    }
}