using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Domain.Products;
using SierraTakeHome.Core.Infrastructure.Data;

namespace SierraTakeHome.Core.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
