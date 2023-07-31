using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Applications.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _repository;

        public ProductAppService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}