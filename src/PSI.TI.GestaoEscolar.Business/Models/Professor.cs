using System;
using System.Collections.ObjectModel;

namespace PSI.TI.GestaoEscolar.Business.Models
{
    public class Professor : Pessoa
    {
        // EF Relation
        public Collection<string> Formacao { get; private set; }
        public Collection<Disciplina> DisciplinasMinistradas { get; set; }
        
        // For EF
        protected Professor()
        {
            Formacao = new Collection<string>();
            DisciplinasMinistradas = new Collection<Disciplina>();
        }

        public Professor(string nome, string cpf, DateTime dataNascimento, Collection<string> formacao) : base(nome, cpf, dataNascimento)
        {
            Formacao = formacao;
        }
    }
}