using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Customers;

namespace SierraTakeHome.Core.Applications.Customers
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IUnitOfWork _repository;

        public CustomerAppService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _repository.Customers.GetAll();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _repository.Customers.GetById(id);
        }
    }
}