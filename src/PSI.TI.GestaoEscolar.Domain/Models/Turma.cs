using PSI.TI.GestaoEscolar.Domain.Models.Enums;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using System;
using System.Collections.Generic;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Turma : Entity
    {
        public ICollection<Matricula> Matriculas { get; private set; }
        public ICollection<Disciplina> DisciplinasOfertadas { get; private set; }
        public SituacaoTurma Situacao { get; private set; }
        public Guid ProfessorId { get; private set; }

        // EF Relation
        public Professor Professor { get; }

        // For EF
        protected Turma()
        {
            Matriculas = new List<Matricula>();
            DisciplinasOfertadas = new List<Disciplina>();
        }

        public Turma(ICollection<Disciplina> disciplinasOfertadas, Guid professorId)
        {
            DisciplinasOfertadas = disciplinasOfertadas;
            Matriculas = new List<Matricula>();
            ProfessorId = professorId;
            TornarAtiva();
        }

        protected Turma(ICollection<Matricula> matriculas, Guid professorId)
        {
            DisciplinasOfertadas = new List<Disciplina>();
            Matriculas = matriculas;
            ProfessorId = professorId;
            TornarAtiva();
        }

        public override bool EhValido() => new TurmaValidation().Validate(this).IsValid;

        public void TornarAtiva() => Situacao = SituacaoTurma.Ativa;

        public void TornarInativa() => Situacao = SituacaoTurma.Inativa;
    }
}