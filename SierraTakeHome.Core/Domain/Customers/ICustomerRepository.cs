namespace SierraTakeHome.Core.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
    }
}