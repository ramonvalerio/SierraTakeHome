using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Repositories
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }

        IProductRepository Products { get; }
    }
}