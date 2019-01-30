using DiskCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiskCommerce.Database.Mappgings
{

    public class DiskMapping : IEntityTypeConfiguration<Disk>
    {
        public void Configure(EntityTypeBuilder<Disk> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(o => o.Description)
             .HasColumnName("Description")
             .HasColumnType("varchar(200)")
             .IsRequired();


            builder.Property(o => o.Genre)
              .HasColumnName("Genre")
              .HasColumnType("integer")
              .IsRequired();
        }
    }
}