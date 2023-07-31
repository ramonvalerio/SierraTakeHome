using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Products;

namespace SierraTakeHome.Core.Applications.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IUnitOfWork _repository;

        public ProductAppService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repository.Products.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _repository.Products.GetById(id);
        }
    }
}