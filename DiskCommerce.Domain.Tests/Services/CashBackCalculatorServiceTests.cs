using DiskCommerce.Domain.Entities.BuyerAggregate;
using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using DiskCommerce.Domain.Enumerators;
using DiskCommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DiskCommerce.Domain.Tests.Services
{
     public class CashBackCalculatorServiceTests
    {

        [Fact]
        public void Must_Calculate_CashBackValue_Correct()
        {

            Buyer buyer = new Buyer(Guid.NewGuid(), "Buyer");

            OrderedDisk orderedDisk1 = new OrderedDisk(Guid.NewGuid(), "Disk 1", DiskGenreEnum.CLASSIC);
            OrderedDisk orderedDisk2 = new OrderedDisk(Guid.NewGuid(), "Disk 2", DiskGenreEnum.MPB);

            OrderItem orderItem1 = new OrderItem(orderedDisk1, 100, 2);
            OrderItem orderItem2 = new OrderItem(orderedDisk2, 50, 2);

            Order order = new Order(buyer, new List<OrderItem>() { orderItem1, orderItem2 });

            CashBackConfigurationService cashBackConfigurationService = new CashBackConfigurationService();

            CashBackCalculatorService cashBackCalculatorService = new CashBackCalculatorService(cashBackConfigurationService);

            OrderCashback orderCashBack =  cashBackCalculatorService.CalculateOrderCashBack(order);

            Assert.Equal(2, orderCashBack.OrderCashbacktems.Count);
            Assert.Equal(30, orderCashBack.OrderCashbackValue);

        }

    }
}
