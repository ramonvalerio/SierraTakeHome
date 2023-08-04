using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using SierraTakeHome.Core.Infrastructure.Data;
using SierraTakeHome.Core.Domain.Orders;

namespace SierraTakeHome.Core.Infrastructure.Repositories
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
            var orderIdParam = new SqlParameter("@OrderID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var parameters = new object[]
            {
                new SqlParameter("@CustomerID", order.CustomerId),
                new SqlParameter("@ProductID", order.ProductId),
                new SqlParameter("@Quantity", order.Quantity),
                orderIdParam
            };

            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC CreateOrder @CustomerID, @ProductID, @Quantity, @OrderID OUTPUT", parameters);

                return (int)orderIdParam.Value; // Return the value of the output parameter
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
