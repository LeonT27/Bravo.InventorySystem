using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.UnitId).IsRequired();

            builder.HasMany(p => p.Transactions)
                .WithOne(t => t.Product)
                .HasForeignKey(t => t.ProductId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
