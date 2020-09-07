using System;

namespace PSI.TI.GestaoEscolar.Business.Models
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }

        // For EF
        protected Pessoa()
        {

        }

        protected Pessoa(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
    }
}
