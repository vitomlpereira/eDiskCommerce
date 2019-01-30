using DiskCommerce.Commom.Publisher;
using DiskCommerce.Domain.Entities.OrderAggregate;

namespace DiskCommerce.Domain.Events
{
    public class OrderPlacedEvent : Event
    {

        public OrderPlacedEvent(Order orderToPLace)
        {
            this.Order = orderToPLace;
        }

        public Order Order { get; set; }
    }
}
