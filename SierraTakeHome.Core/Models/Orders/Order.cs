namespace SierraTakeHome.Core.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int TotalCost { get; set; }
    }
}