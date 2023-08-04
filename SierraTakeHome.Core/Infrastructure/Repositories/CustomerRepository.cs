using Microsoft.EntityFrameworkCore;
using SierraTakeHome.Core.Domain.Customers;
using SierraTakeHome.Core.Infrastructure.Data;

namespace SierraTakeHome.Core.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}