using DiskCommerce.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiskCommerce.Database.Mappgings
{

    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.UnitPrice)
                .HasColumnName("UnitPrice")
                .HasColumnType("decimal(5, 2)")
                .IsRequired();

            builder.Property(o => o.Units)
                  .HasColumnName("Unit")
                  .HasColumnType("decimal(5, 2)")
                  .IsRequired();

            builder.OwnsOne(o => o.OrderedDisk, od =>
            {
                od.Property(p => p.DiskId).HasColumnName("DiskID");
                od.Property(p => p.Genre).HasColumnName("DiskGenre");
                od.Property(p => p.Name).HasColumnName("DiskName");
            });
               
        }
    }
}