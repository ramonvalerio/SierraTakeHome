using Microsoft.EntityFrameworkCore.Storage;
using SierraTakeHome.Core.Domain.Customers;
using SierraTakeHome.Core.Domain.Orders;
using SierraTakeHome.Core.Domain.Products;
using SierraTakeHome.Core.Infrastructure.Repositories;

namespace SierraTakeHome.Core.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IDbContextTransaction _transaction;

        public IProductRepository Products { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(DataContext context)
        {
            Products = new ProductRepository(context);
            Customers = new CustomerRepository(context);
            Orders = new OrderRepository(context);
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context?.Dispose();
        }
    }
}