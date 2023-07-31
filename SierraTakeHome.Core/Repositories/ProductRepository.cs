using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Models.Products;
using System.Linq;

namespace SierraTakeHome.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public Product GetById(int id)
        {
            return _context.Set<Product>().Find(id);
        }

        public void Add(Product product)
        {
            _context.Set<Product>().Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                _context.SaveChanges();
            }
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Set<Product>().AsQueryable();
        }
    }
}
