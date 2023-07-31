using System.ComponentModel.DataAnnotations;

namespace SierraTakeHome.Core.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Price { get; set; }
    }
}