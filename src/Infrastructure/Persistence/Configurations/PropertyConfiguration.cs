using WeeloApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeeloApi.Infrastructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.HasKey(x => x.IdProperty);
            builder.Property(t => t.Name)
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);
            builder.Property(t => t.Address)
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);
            builder.Property(t => t.Price)
            .HasColumnType("decimal(28,4)")
            .HasPrecision(28, 4);
            builder.HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(s => s.IdOwner)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
