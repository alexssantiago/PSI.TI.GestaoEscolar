using FluentValidation;

namespace PSI.TI.GestaoEscolar.Domain.Models.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MinLength} caracteres.");

            //RuleFor(p => p.Cpf)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");

            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");
        }
    }
}