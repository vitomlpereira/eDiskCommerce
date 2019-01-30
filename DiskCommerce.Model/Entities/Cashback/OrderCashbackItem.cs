using DiskCommerce.Commom.AggregateRoots;
using DiskCommerce.Commom.Entities;
using DiskCommerce.Domain.Entities.OrderAggregate;

namespace DiskCommerce.Domain.Entities.CashbackAggregate
{
    public class OrderCashbackItem : BaseEntity, IAggregateRoot
    {
        protected OrderCashbackItem() {}

        public OrderCashbackItem(OrderItem relatedOrderItem, decimal cashbackPercentage)
        {
            RelatedOrderItem = relatedOrderItem;
            CashbackPercentage = cashbackPercentage;
            CashbackValue = ((RelatedOrderItem.UnitPrice * relatedOrderItem.Units) * CashbackPercentage) / 100 ;
        }

        public OrderItem RelatedOrderItem { get; private set; }
        public decimal CashbackPercentage { get; private set; }
        public decimal CashbackValue { get; private set; }

    }
}