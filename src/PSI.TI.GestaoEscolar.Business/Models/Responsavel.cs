using System;
using System.Collections.ObjectModel;

namespace PSI.TI.GestaoEscolar.Business.Models
{
    public class Responsavel : Pessoa
    {
        public string GrauParentesco { get; private set; }
        public string Ocupacao { get; private set; }
        public decimal Renda { get; private set; }
        public string NomeContato { get; private set; }
        public int TelContato { get; private set; }

        // EF Relation
        public Collection<Aluno> Filhos { get; private set; }

        //For EF
        protected Responsavel()
        {
            Filhos = new Collection<Aluno>();
        }

        public Responsavel(string nome, string cpf, DateTime dataNascimento, string grauParentesco, string ocupacao, decimal renda, string nomeContato, int telContato) 
            : base(nome, cpf, dataNascimento)
        {
            GrauParentesco = grauParentesco;
            Ocupacao = ocupacao;
            Renda = renda;
            NomeContato = nomeContato;
            TelContato = telContato;
        }
    }
}