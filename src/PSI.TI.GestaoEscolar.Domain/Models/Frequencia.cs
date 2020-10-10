using System;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Frequencia : Entity
    {
        public DateTime Data { get; private set; }
        public Guid AlunoId { get; private set; }
        public bool Presenca { get; private set; }

        // EF Relation
        public Aluno Aluno { get; private set; }

        // For EF
        protected Frequencia()
        {
            
        }

        public Frequencia(DateTime data, Guid alunoId, bool presenca)
        {
            Data = data;
            AlunoId = alunoId;
            Presenca = presenca;
        }

        public void RegistrarPresenca() => Presenca = true;
        public void RegistrarAusencia() => Presenca = false;
        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}