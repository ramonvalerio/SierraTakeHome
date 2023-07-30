namespace SierraTakeHome.Core.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Price { get; set; }
    }
}