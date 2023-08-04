using SierraTakeHome.Core.Domain.Products;

namespace SierraTakeHome.Core.Application.Products
{
    public interface IProductAppService
    {
        Task<List<Product>> GetAll();

        Task<Product> GetById(int id);
    }
}