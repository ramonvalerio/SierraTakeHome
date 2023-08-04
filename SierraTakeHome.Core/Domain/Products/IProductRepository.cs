namespace SierraTakeHome.Core.Domain.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
    }
}