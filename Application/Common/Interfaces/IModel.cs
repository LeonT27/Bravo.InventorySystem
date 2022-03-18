using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IModel
    {
        DbSet<Product> Products { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }
        DbSet<Unit> Units { get; set; }

        Task<int> SaveChangesAsync();
    }
}
