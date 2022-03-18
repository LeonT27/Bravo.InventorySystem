using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Unit {Id = 1, Name = "Unidad"},
                new Unit {Id = 2, Name = "Docena"}
            );
        }
    }
}
