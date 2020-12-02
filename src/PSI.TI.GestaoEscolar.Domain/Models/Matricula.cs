using System;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Matricula
    {
        public Guid AlunoId { get; private set; }
        public Guid TurmaId { get; private set; }

        public Aluno Aluno { get; }
        public Turma Turma { get; }

        public Matricula(Guid alunoId, Guid turmaId)
        {
            AlunoId = alunoId;
            TurmaId = turmaId;
        }
    }
}