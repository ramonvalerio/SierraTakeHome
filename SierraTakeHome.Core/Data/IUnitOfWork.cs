using SierraTakeHome.Core.Models.Customers;
using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Data
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