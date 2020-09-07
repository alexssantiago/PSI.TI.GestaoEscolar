using System;
using System.Collections.ObjectModel;

namespace PSI.TI.GestaoEscolar.Business.Models
{
    public class Turma : Entity
    {
        public Collection<Aluno> Alunos { get; private set; }
        public Guid ProfessorId { get; private set; }
        public Guid DisciplinaId { get; private set; }

        // EF Relation
        public Professor Professor { get; private set; }
        public Disciplina Disciplina { get; private set; }

        // For EF
        protected Turma()
        {
            Alunos = new Collection<Aluno>();
        }

        protected Turma(Collection<Aluno> alunos, Guid professorId, Guid disciplinaId)
        {
            Alunos = alunos;
            ProfessorId = professorId;
            DisciplinaId = disciplinaId;
        }
    }
}