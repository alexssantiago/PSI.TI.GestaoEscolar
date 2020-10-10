using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSI.TI.GestaoEscolar.Application.ViewModels
{
    public class AlunoViewModel
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
        public Guid Matricula { get; set; }
        
        [DisplayName("Situação")]
        public int Situacao { get; set; }
        
        public Guid ResponsavelId { get; set; }
        public ResponsavelViewModel Responsavel { get; set; }
    }
}