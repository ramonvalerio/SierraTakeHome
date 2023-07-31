using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }

        public UnitOfWork(IOrderRepository orders, IProductRepository products)
        {
            Orders = orders;
            Products = products;
        }
    }
}