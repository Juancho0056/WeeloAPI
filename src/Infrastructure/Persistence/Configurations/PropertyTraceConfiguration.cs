using WeeloApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeeloApi.Infrastructure.Persistence.Configurations
{
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.HasKey(x => x.IdPropertyTrace);
            builder.Property(t => t.Name)
            .HasColumnType("varchar(150)")
            .HasMaxLength(150);
            builder.Property(t => t.Value)
            .HasColumnType("decimal(28,4)")
            .HasPrecision(28, 4);
            builder.Property(t => t.Tax)
            .HasColumnType("decimal(28,4)")
            .HasPrecision(28, 4);
            builder.HasOne(t => t.Property)
                .WithMany()
                .HasForeignKey(s => s.IdProperty)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
