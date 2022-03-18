using System;

namespace Application.Services.ProductService.Dto
{
    public class ProductHistory
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime Created { get; set; }
    }
}
