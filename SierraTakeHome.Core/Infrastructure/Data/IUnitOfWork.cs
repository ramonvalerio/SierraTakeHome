using SierraTakeHome.Core.Domain.Customers;
using SierraTakeHome.Core.Domain.Orders;
using SierraTakeHome.Core.Domain.Products;

namespace SierraTakeHome.Core.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ICustomerRepository Customers { get; }
        Task CommitAsync();
        Task BeginTransactionAsync();
        Task RollbackAsync();
    }
}