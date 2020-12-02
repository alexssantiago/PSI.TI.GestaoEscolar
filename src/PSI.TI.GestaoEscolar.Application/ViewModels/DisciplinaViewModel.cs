using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSI.TI.GestaoEscolar.Application.ViewModels
{
    public class DisciplinaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Carga Horária")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CargaHoraria { get; set; }

        public Guid? TurmaId { get; set; }
        public TurmaViewModel Turma { get; set; }
    }
}