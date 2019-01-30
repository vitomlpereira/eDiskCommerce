using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Interfaces;
using System;

namespace DiskCommerce.Domain.Services
{
    public class CashBackCalculatorService : ICashBackCalculatorService
    {
        private readonly ICashBackConfigurationService _cashBackConfigurationService;

        public CashBackCalculatorService(ICashBackConfigurationService cashBackConfigurationService)
        {
            _cashBackConfigurationService = cashBackConfigurationService;
        }

        public OrderCashback CalculateOrderCashBack(Order order)
        {
            OrderCashback orderCashBack = new OrderCashback(order);

            foreach (var orderItem in order.OrderItems)
            {
                var cashbackPercentage = GetCashbackPercentage(order.OrderDate, orderItem.OrderedDisk.Genre);
                orderCashBack.AddCashbackOrderItem(new OrderCashbackItem(orderItem, cashbackPercentage));
            }
           
            return orderCashBack;
        }

        private decimal GetCashbackPercentage(DateTime orderDate, DiskGenreEnum genre)
        {
            return _cashBackConfigurationService.GetPercentage(genre, orderDate);
        }
    }
}
