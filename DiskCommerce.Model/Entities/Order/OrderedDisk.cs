using DiskCommerce.Domain.Enumerators;
using System;

namespace DiskCommerce.Domain.Entities.OrderAggregate
{
    public class OrderedDisk
    {
        public OrderedDisk(Guid diskId, string name, DiskGenreEnum genre)
        {
            DiskId = diskId;
            Name = name;
            Genre = genre;
        }

        public Guid DiskId { get; private set; }
        public string Name { get; private set; }
        public DiskGenreEnum Genre { get; private set; }
    }
}