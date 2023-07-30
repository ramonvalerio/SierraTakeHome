namespace SierraTakeHome.Core.Domain.Products
{
    public class Product
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int TotalCost { get; set; }
    }
}