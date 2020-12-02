using PSI.TI.GestaoEscolar.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSI.TI.GestaoEscolar.Application.ViewModels
{
    public class TurmaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Situação")]
        public SituacaoTurma Situacao { get; set; }

        public Guid ProfessorId { get; set; }
        public ProfessorViewModel Professor { get; set; }

        public List<MatriculaViewModel> Matriculas { get; set; }
        
        public List<DisciplinaViewModel> DisciplinasOfertadas { get; set; }
    }
}