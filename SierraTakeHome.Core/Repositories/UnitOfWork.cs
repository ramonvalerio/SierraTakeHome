using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }

        public UnitOfWork(DataContext context)
        {
            Orders = new OrderRepository(context);
            Products = new ProductRepository(context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}