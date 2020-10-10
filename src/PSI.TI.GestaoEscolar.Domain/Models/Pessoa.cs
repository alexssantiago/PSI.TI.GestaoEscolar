using System;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; }
        public long Cpf { get; }
        public DateTime DataNascimento { get; }

        // For EF
        protected Pessoa()
        {

        }

        protected Pessoa(string nome, long cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public override bool EhValido()
        {
            var validationResult = new PessoaValidation().Validate(this);
            return validationResult.IsValid;
        }
    }
}
