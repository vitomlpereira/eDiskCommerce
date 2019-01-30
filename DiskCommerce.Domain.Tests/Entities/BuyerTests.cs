using DiskCommerce.Domain.Entities.BuyerAggregate;
using System;
using Xunit;

namespace DiskCommerce.Domain.Tests.Entities
{
    public class BuyerTests
    {
        Guid id = Guid.NewGuid();
        String name = "New Buyer";

        [Fact]
        public void New_Buyer_Should_Pass()
        {
            var buyer = new Buyer(id, name);

            Assert.NotNull(buyer);
            Assert.Equal(id, buyer.Id);
            Assert.Equal(name, buyer.Name);

        }
    }
}
