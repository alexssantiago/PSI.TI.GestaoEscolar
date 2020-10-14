using FluentValidation;

namespace PSI.TI.GestaoEscolar.Domain.Models.Validations
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public static string ResponsavelIdErroMsg => "O Id do Responsável precisa ser fornecido.";

        public AlunoValidation()
        {
            Include(new PessoaValidation());

            RuleFor(a => a.ResponsavelId)
                .NotEmpty().WithMessage(ResponsavelIdErroMsg);
        }
    }
}