using DiskCommerce.Commom.AggregateRoots;
using DiskCommerce.Commom.Entities;
using DiskCommerce.Domain.Entities.OrderAggregate;
using DiskCommerce.Domain.Exceptions;
using System.Collections.Generic;

namespace DiskCommerce.Domain.Entities.CashbackAggregate
{
    public class OrderCashback:  BaseEntity, IAggregateRoot
    {
        public Order RelatedOrder { get; private set; }
        public decimal OrderCashbackValue { get; private set; }

        //private readonly List<OrderCashbackItem> _orderCashbackItem = new List<OrderCashbackItem>();
        //public IReadOnlyCollection<OrderCashbackItem> OrderCashbacktems => _orderCashbackItem.AsReadOnly();

        public List<OrderCashbackItem> OrderCashbacktems { get; set; } = new List<OrderCashbackItem>();
        protected OrderCashback() {}

        public OrderCashback(Order relatedOrder)
        {
            Guardian.CheckNull(relatedOrder);

            RelatedOrder = relatedOrder;
        }

        public void AddCashbackOrderItem(OrderCashbackItem orderCashbackItem)
        {
            OrderCashbackValue += orderCashbackItem.CashbackValue;
            //this._orderCashbackItem.Add(orderCashbackItem);
            this.OrderCashbacktems.Add(orderCashbackItem);
        }

    }
}
