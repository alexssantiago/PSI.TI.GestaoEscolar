using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Professor : Pessoa
    {
        public ICollection<string> Formacao { get; private set; }

        // EF Relation
        public ICollection<Disciplina> DisciplinasMinistradas { get; set; }
        
        // For EF
        protected Professor()
        {
            Formacao = new Collection<string>();
        }

        public Professor(string nome, long cpf, DateTime dataNascimento, ICollection<string> formacao) : base(nome, cpf, dataNascimento)
        {
            Formacao = formacao;
        }
    }
}