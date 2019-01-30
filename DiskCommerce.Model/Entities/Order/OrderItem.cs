using DiskCommerce.Commom.Entities;

namespace DiskCommerce.Domain.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {


        public OrderedDisk OrderedDisk { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        private OrderItem() {}

        public OrderItem(OrderedDisk orderedDisk, decimal unitPrice, int units)
        {
            OrderedDisk = orderedDisk;
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}
