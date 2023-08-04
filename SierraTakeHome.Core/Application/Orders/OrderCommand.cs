namespace SierraTakeHome.Core.Application.Orders
{
    public class OrderCommand
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public void IsValid()
        {
            if (CustomerId < 1)
                throw new ArgumentException("Invalid CustomerId.");

            if (ProductId < 1)
                throw new ArgumentException("Invalid ProductId.");

            if (Quantity < 1)
                throw new ArgumentException("Invalid Quantity.");
        }
    }
}