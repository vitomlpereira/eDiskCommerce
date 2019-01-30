using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiskCommerce.Database.Mappgings
{

    public class OrderCashbackItemMapping : IEntityTypeConfiguration<OrderCashbackItem>
    {
        public void Configure(EntityTypeBuilder<OrderCashbackItem> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("OrderId")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.CashbackValue)
                .HasColumnName("CashbackValue")
                .HasColumnType("decimal(5, 2)")
                .IsRequired();

            builder.Property(o => o.CashbackPercentage)
                  .HasColumnName("CashbackPercentage")
                  .HasColumnType("decimal(5, 2)")
                  .IsRequired();

            builder.HasOne(o => o.RelatedOrderItem);
        }
    }
}