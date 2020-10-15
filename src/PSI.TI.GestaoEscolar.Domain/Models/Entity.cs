using System;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract bool EhValido();
    }
}