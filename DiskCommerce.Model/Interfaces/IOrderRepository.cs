using DiskCommerce.Commom.Pagging;
using DiskCommerce.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiskCommerce.Domain.Interfaces
{
    public interface IOrderRepository
    {
        PagedResult<Order> GetPagged(int actualPage, int pageSize, DateTime begin, DateTime end);
        Order Get(Guid id);
        void PlaceOrder(Order order);
    }
}
