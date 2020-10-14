using FluentValidation;
using PSI.TI.GestaoEscolar.Domain.Models.Validations.Documentos;

namespace PSI.TI.GestaoEscolar.Domain.Models.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MinLength} caracteres.");

            RuleFor(f => f.Cpf.ToString().Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CpfValidacao.Validar(f.Cpf.ToString())).Equal(true)
                .WithMessage("O CPF fornecido é inválido.");

            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");
        }
    }
}