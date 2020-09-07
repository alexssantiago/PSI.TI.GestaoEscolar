using System;

namespace PSI.TI.GestaoEscolar.Business.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}