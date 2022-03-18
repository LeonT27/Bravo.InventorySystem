using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.Purpose).IsRequired().HasMaxLength(100);
            builder.Property(t => t.ProductId).IsRequired();
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.TransactionTypeId).IsRequired();
        }
    }
}
