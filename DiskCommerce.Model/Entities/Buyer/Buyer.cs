using DiskCommerce.Commom.AggregateRoots;
using DiskCommerce.Commom.Entities;
using System;


namespace DiskCommerce.Domain.Entities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Buyer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
