using FluentValidation;

namespace PSI.TI.GestaoEscolar.Domain.Models.Validations
{
    public class TurmaValidation : AbstractValidator<Turma>
    {
        public static string ProfessorIdErroMsg => "O Id do(a) Professor(a) precisa ser fornecido.";

        public TurmaValidation()
        {
            RuleFor(a => a.ProfessorId)
                .NotEmpty().WithMessage(ProfessorIdErroMsg);
        }
    }
}