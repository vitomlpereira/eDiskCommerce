using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.BuyerAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using Xunit;

namespace DiskCommerce.Domain.Tests
{
    public class OrderTests
    {
        Buyer buyer = new Buyer(Guid.NewGuid(), "Buyer name");

        
        String diskName1 = "Disk 1";
        String discDescription1 = "Disk 1 Description";

        
        String diskName2 = "Disk 2";
        String discDescription2 = "Disk 2 Description";

        
        String diskName3 = "Disk 3";
        String discDescription3 = "Disk 3 Description";


        [Fact]
        public void Valid_Order_Should_Pass()
        {

            var disc1 = new Disk( diskName1, discDescription1, 50, Enumerators.DiskGenreEnum.CLASSIC);
            var disc2 = new Disk( diskName2, discDescription2, 50, Enumerators.DiskGenreEnum.ROCK);
            var disc3 = new Disk( diskName3, discDescription3, 50, Enumerators.DiskGenreEnum.POP);


            var orderItens = new List<OrderItem>()
            {
                new OrderItem(new OrderedDisk(disc1.Id,disc1.Name,disc1.Genre),disc1.Price,1),
                new OrderItem(new OrderedDisk(disc2.Id,disc2.Name,disc2.Genre),disc2.Price,1),
                new OrderItem(new OrderedDisk(disc3.Id,disc3.Name,disc3.Genre),disc3.Price,1)
            };

            var order = new Order(buyer, orderItens);

            Assert.NotNull(order);
            Assert.Equal(3, order.OrderItems.Count);
            Assert.Equal(buyer.Id, order.Buyer.Id);

        }


        [Fact]
        public void Invalid_Price_Order_Should_Fail()
        {

            var orderedDisk1 = new Disk( diskName1, discDescription1, 50, Enumerators.DiskGenreEnum.CLASSIC);
            var orderedDisk2 = new Disk( diskName2, discDescription2, 50, Enumerators.DiskGenreEnum.ROCK);
            var orderedDisk3 = new Disk( diskName3, discDescription3, 50, Enumerators.DiskGenreEnum.POP);


            var orderItens = new List<OrderItem>()
            {
                new OrderItem(new OrderedDisk(orderedDisk1.Id,orderedDisk1.Name,orderedDisk1.Genre),orderedDisk1.Price,1),
                new OrderItem(new OrderedDisk(orderedDisk2.Id,orderedDisk2.Name,orderedDisk2.Genre),orderedDisk2.Price,1),
                new OrderItem(new OrderedDisk(orderedDisk3.Id,orderedDisk3.Name,orderedDisk3.Genre),orderedDisk3.Price,1)
            };

            var order = new Order(buyer, orderItens);

            Assert.NotNull(order);
            Assert.Equal(3, order.OrderItems.Count);
            Assert.Equal(buyer.Id, order.Buyer.Id);

        }

    }
}
