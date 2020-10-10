using System;
using System.Collections.Generic;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Turma : Entity
    {
        public ICollection<Aluno> Alunos { get; set; }
        public Guid ProfessorId { get; private set; }
        public Guid DisciplinaId { get; private set; }

        // EF Relation
        public Professor Professor { get; private set; }
        public Disciplina Disciplina { get; private set; }

        // For EF
        protected Turma()
        {

        }

        protected Turma(ICollection<Aluno> alunos, Guid professorId, Guid disciplinaId)
        {
            Alunos = alunos;
            ProfessorId = professorId;
            DisciplinaId = disciplinaId;
        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}