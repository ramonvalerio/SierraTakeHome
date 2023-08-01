using SierraTakeHome.Core.Models.Customers;

namespace SierraTakeHome.Core.Applications.Customers
{
    public interface ICustomerAppService
    {
        Task<List<Customer>> GetAll();

        Task<Customer> GetById(int id);
    }
}