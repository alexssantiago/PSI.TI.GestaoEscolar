using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSI.TI.GestaoEscolar.Application.ViewModels
{
    public class ResponsavelViewModel
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

        [DisplayName("Parentesco")]
        public string GrauParentesco { get; set; }

        [DisplayName("Ocupação")]
        public string Ocupacao { get; set; }
        
        public decimal Renda { get; set; }

        [DisplayName("Nome do Contato")]
        public string NomeContato { get; set; }

        [DisplayName("Telefone do Contato")]
        public long TelefoneContato { get; set; }

        public List<AlunoViewModel> Dependentes { get; set; }
    }
}