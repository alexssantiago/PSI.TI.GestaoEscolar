using FluentValidation;

namespace PSI.TI.GestaoEscolar.Domain.Models.Validations
{
    public class DisciplinaValidation : AbstractValidator<Disciplina>
    {
        public DisciplinaValidation()
        {
            RuleFor(d => d.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MinLength} caracteres.");

            RuleFor(d => d.CargaHoraria)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}.");
        }
    }
}