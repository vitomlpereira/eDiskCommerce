using DiskCommerce.Domain.Entities.CashbackAggregate;
using DiskCommerce.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiskCommerce.Database.Mappgings
{

    public class OrderCashbackMapping : IEntityTypeConfiguration<OrderCashback>
    {
        public void Configure(EntityTypeBuilder<OrderCashback> builder)
        {
            builder.ToTable("Cashback");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.HasOne(p => p.RelatedOrder);

            builder.HasMany(o => o.OrderCashbacktems)
               .WithOne()
               .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
 
            builder.Property(o => o.OrderCashbackValue)
                .HasColumnName("CashbackValue")
                .HasColumnType("decimal(5, 2)")
                .IsRequired();
        }
    }
}