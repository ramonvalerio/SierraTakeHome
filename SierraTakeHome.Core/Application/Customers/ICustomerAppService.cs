using SierraTakeHome.Core.Domain.Customers;

namespace SierraTakeHome.Core.Application.Customers
{
    public interface ICustomerAppService
    {
        Task<List<Customer>> GetAll();

        Task<Customer> GetById(int id);
    }
}