namespace SierraTakeHome.Core.Models.Customers
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
    }
}