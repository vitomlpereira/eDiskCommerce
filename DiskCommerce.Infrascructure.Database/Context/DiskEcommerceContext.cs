using DiskCommerce.Database.Mappgings;
using DiskCommerce.Domain.Entities;
using DiskCommerce.Domain.Entities.BuyerAggregate;
using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DiskCommerce.Database.Context
{
    public class DiskEcommerceContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<OrderCashback> Cashbacks { get; set; }


        public DiskEcommerceContext(DbContextOptions<DiskEcommerceContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuyerMapping());
            modelBuilder.ApplyConfiguration(new DiskMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new OrderItemMapping());
            modelBuilder.ApplyConfiguration(new OrderCashbackItemMapping());
            modelBuilder.ApplyConfiguration(new OrderCashbackMapping());
         

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), o => o.UseRowNumberForPaging());
            }


        }
    }
}
