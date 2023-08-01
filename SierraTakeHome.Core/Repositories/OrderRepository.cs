using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Orders;
using Microsoft.Data.SqlClient;

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
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@CustomerID", order.CustomerID),
                new SqlParameter("@ProductID", order.ProductId),
                new SqlParameter("@Quantity", order.Quantity)
            };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC CreateOrder @CustomerID, @ProductID, @Quantity",
                parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
