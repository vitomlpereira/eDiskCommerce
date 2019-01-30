using DiskCommerce.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiskCommerce.Database.Mappgings
{

    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("OrderId")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.OrderDate)
                .HasColumnName("OrderDate")
                .HasColumnType("Datetime")
                .IsRequired();

            builder
                .HasMany(o => o.OrderItems)
                .WithOne()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(o => o.Buyer)
                .WithMany();
            
        }
    }
}