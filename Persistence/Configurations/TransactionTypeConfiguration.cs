using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.Property(tt => tt.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                new TransactionType { Id = 1, Name = "Entrada", Operation = '+'},
                new TransactionType { Id = 2, Name = "Modificar", Operation = '+' },
                new TransactionType { Id = 3, Name = "Modificar", Operation = '-' },
                new TransactionType { Id = 4, Name = "Mermas", Operation = '-' }
            );
        }
    }
}
