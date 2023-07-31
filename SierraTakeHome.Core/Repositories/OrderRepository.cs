using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Orders;
using System.Data.SqlClient;

namespace SierraTakeHome.Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<int> Create(Order order)
        {
            var customerIdParam = new SqlParameter("@CustomerID", order.CustomerID);
            var productIdParam = new SqlParameter("@ProductID", order.ProductId);
            var quantityParam = new SqlParameter("@Quantity", order.Quantity);

            return await _context.Database.ExecuteSqlRawAsync("EXEC CreateOrder @CustomerID, @ProductID, @Quantity",
                customerIdParam, productIdParam, quantityParam);
        }
    }
}
