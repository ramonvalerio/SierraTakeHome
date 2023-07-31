using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Applications.Products
{
    public interface IProductAppService
    {
        Task<List<Product>> GetAll();

        Task<Product> GetById(int id);
    }
}