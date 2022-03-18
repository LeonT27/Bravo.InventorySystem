using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Product : AuditEntity
    {
        public Product()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
