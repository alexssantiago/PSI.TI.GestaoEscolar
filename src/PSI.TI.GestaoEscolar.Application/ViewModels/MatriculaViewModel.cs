using System;

namespace PSI.TI.GestaoEscolar.Application.ViewModels
{
    public class MatriculaViewModel
    {
        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }

        public AlunoViewModel Aluno { get; set; }
        public TurmaViewModel Turma { get; set; }
    }
}