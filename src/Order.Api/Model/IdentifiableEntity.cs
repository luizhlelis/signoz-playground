using System;

namespace Order.Api.Model
{
    public abstract class IdentifiableEntity
    {
        public Guid Id { get; protected set; }

        public IdentifiableEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}