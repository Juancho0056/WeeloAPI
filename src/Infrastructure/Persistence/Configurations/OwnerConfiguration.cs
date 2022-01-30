using WeeloApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeeloApi.Infrastructure.Persistence.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(x => x.IdOwner);
            builder.Property(t => t.Name)
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);
            builder.Property(t => t.Address)
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);
            builder.Property(t => t.Photo)
            .HasColumnType("varchar(150)");

        }
    }
}
