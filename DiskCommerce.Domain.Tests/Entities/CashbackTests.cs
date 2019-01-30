using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.BuyerAggregate;
using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using DiskCommerce.Domain.Enumerators;
using System;
using System.Collections.Generic;
using Xunit;

namespace DiskCommerce.Domain.Tests
{
    public class CashbackTests
    {

        [Fact]
        public void CashBackItemValue_Must_Be_Correct()
        {
            Guid orderedDiskID = Guid.NewGuid();
            String orderedDiskName = "ordered disk name";
            DiskGenreEnum orderDiskGenre = Enumerators.DiskGenreEnum.CLASSIC;
            decimal orderedDiskPrice = 100;
            int orderedDiskUnit = 2;
            decimal cashBackPercentage = 25;

            OrderedDisk orderedDisk = new OrderedDisk(orderedDiskID, orderedDiskName, orderDiskGenre);
            OrderItem orderItem = new OrderItem(orderedDisk, orderedDiskPrice, orderedDiskUnit);
            OrderCashbackItem cashbackItem = new OrderCashbackItem(orderItem, cashBackPercentage);
            
            
            Assert.Equal(cashBackPercentage, cashbackItem.CashbackPercentage);
            Assert.Equal(50, cashbackItem.CashbackValue);

        }

        [Fact]
        public void CashBackOrderTotalValue_Must_Be_Correct()
        {

            Buyer buyer = new Buyer(Guid.NewGuid(), "Buyer");

            OrderedDisk orderedDisk1 = new OrderedDisk(Guid.NewGuid(), "Disk 1", DiskGenreEnum.CLASSIC);
            OrderedDisk orderedDisk2 = new OrderedDisk(Guid.NewGuid(), "Disk 2", DiskGenreEnum.MPB);

            OrderItem orderItem1 = new OrderItem(orderedDisk1, 100, 2);
            OrderItem orderItem2 = new OrderItem(orderedDisk2, 50, 4);

            Order order = new Order(buyer, new List<OrderItem>() { orderItem1, orderItem2 });

            OrderCashback orderCashback = new OrderCashback(order);

            OrderCashbackItem cashbackItem1 = new OrderCashbackItem(orderItem1, 25);
            OrderCashbackItem cashbackItem2 = new OrderCashbackItem(orderItem2, 50);

            orderCashback.AddCashbackOrderItem(cashbackItem1);
            orderCashback.AddCashbackOrderItem(cashbackItem2);


            Assert.Equal(50, cashbackItem1.CashbackValue);
            Assert.Equal(100, cashbackItem2.CashbackValue);
            Assert.Equal(150, orderCashback.OrderCashbackValue);


        }

    }
}
