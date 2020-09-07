using System;
using System.Collections.ObjectModel;

namespace PSI.TI.GestaoEscolar.Business.Models
{
    public class Chamada : Entity
    {
        public Guid AulaId { get; private set; }
        public DateTime Data { get; private set; }
        public Collection<Aluno> Alunos { get; private set; }
        public Collection<Frequencia> FrequenciaAlunos { get; private set; }

        // EF Relation
        public Aula Aula { get; private set; }

        // For EF
        protected Chamada()
        {
            Alunos = new Collection<Aluno>();
            FrequenciaAlunos = new Collection<Frequencia>();
        }

        public Chamada(Guid aulaId, DateTime data)
        {
            AulaId = aulaId;
            Data = data;
        }

        public void EfetuarChamada()
        {

        }
    }
}