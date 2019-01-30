using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;

namespace DiskCommerce.Domain.Interfaces
{
    public interface ICashBackCalculatorService
    {
        OrderCashback CalculateOrderCashBack(Order order);
    }
}