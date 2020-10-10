using System;
using FluentValidation.Results;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract bool EhValido();
    }
}