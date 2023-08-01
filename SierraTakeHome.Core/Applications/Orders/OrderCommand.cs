namespace SierraTakeHome.Core.Applications.Orders
{
    public class OrderCommand
    {
        public int CustomerID { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}