using FluentValidation;

namespace PSI.TI.GestaoEscolar.Domain.Models.Validations
{
    public class ResponsavelValidation : AbstractValidator<Responsavel>
    {
        public ResponsavelValidation()
        {
            RuleFor(r => r.GrauParentesco)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MinLength} caracteres.");

            RuleFor(r => r.Ocupacao)
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MinLength} caracteres.");

            RuleFor(r => r.Renda)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}.");

            RuleFor(r => r.Nome)
                .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MinLength} caracteres.");
        }
    }
}