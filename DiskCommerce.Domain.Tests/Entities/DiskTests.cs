using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Exceptions;
using System;
using Xunit;

namespace DiskCommerce.Domain.Tests
{
    public class DiskTest
    {
        Guid diskID = Guid.NewGuid();
        String diskName = "New Disc";
        String discDescription = "Disc Description";


        [Fact]
        public void Valid_Disk_Must_Pass()
        {
            var disc = new Disk(diskName,discDescription, 50 , Enumerators.DiskGenreEnum.CLASSIC );

            Assert.NotNull(disc);
            Assert.Equal(diskName, disc.Name);
            Assert.Equal(50, disc.Price);
            Assert.Equal(Enumerators.DiskGenreEnum.CLASSIC, disc.Genre);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(10000)]
        [InlineData(20000)]
        public void Invalid_Disk_Price_Must_Fail(decimal invalidPrice)
        {

            Assert.Throws<ArgumentOutOfRangeException>(() => new Disk(diskName, discDescription, invalidPrice, Enumerators.DiskGenreEnum.CLASSIC));
          
        }
    }
}
