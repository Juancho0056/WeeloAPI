using WeeloApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeeloApi.Infrastructure.Persistence.Configurations
{
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.HasKey(x => x.IdPropertyImage);
            builder.Property(t => t.File)
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);
            builder.HasOne(t => t.Property)
                .WithMany()
                .HasForeignKey(s => s.IdProperty)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
