using Domain.Common;

namespace Domain.Entities
{
    public class Transaction : AuditEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Purpose { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}