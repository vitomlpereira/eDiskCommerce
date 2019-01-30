using DiskCommerce.Domain.Entities.CashbackAggregate;
using System;
using System.Collections.Generic;

namespace DiskCommerce.Domain.Interfaces
{
    public interface ICashBackRepository
    {
        void AddOrderCashBack(OrderCashback orderCashback);
        OrderCashback GetOrderCashBack(Guid orderID);
        
    }
}
