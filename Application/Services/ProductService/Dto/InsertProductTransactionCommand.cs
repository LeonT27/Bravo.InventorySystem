namespace Application.Services.ProductService.Dto
{
    public class InsertProductTransactionCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Purpose { get; set; }
        public int TransactionTypeId { get; set; }
    }
}
