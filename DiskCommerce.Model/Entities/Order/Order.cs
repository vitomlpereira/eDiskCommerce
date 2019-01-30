using DiskCommerce.Commom.AggregateRoots;
using DiskCommerce.Commom.Entities;
using DiskCommerce.Domain.Entities.BuyerAggregate;
using DiskCommerce.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace DiskCommerce.Domain.Entities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {

        protected Order() { }

        public Order(Buyer buyer, List<OrderItem> items)
        {
            Guardian.CheckNull(buyer);
            Guardian.CheckRange(items.Count, 0, 11);

            Buyer = buyer;
            _orderItems = items;
            OrderDate = DateTime.Now; 
        }

        public Buyer Buyer { get; private set; }
        public DateTime OrderDate { get; private set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        

    }
}
