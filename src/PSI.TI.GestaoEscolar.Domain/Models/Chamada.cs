using System;
using System.Collections.Generic;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Chamada : Entity
    {
        public Guid AulaId { get; private set; }
        public DateTime Data { get; private set; }
        public ICollection<Aluno> Alunos { get; set; }
        public ICollection<Frequencia> FrequenciaAlunos { get; set; }

        // EF Relation
        public Aula Aula { get; private set; }

        // For EF
        protected Chamada()
        {

        }

        public Chamada(Guid aulaId, DateTime data)
        {
            AulaId = aulaId;
            Data = data;
        }

        public void EfetuarChamada()
        {

        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}