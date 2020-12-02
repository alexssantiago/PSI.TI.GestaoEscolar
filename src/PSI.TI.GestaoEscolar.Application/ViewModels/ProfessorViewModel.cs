using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSI.TI.GestaoEscolar.Application.ViewModels
{
    public class ProfessorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long Cpf { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Formação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<string> Formacao { get; set; }

        public List<TurmaViewModel> Turmas { get; set; }
    }
}