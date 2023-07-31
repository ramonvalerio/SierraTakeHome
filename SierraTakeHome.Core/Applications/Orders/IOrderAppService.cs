using SierraTakeHome.Core.Models.Orders;

namespace SierraTakeHome.Core.Applications.Orders
{
    public interface IOrderAppService
    {
        Task<List<Order>> GetAll();

        Task<Order> GetById(int id);

        Task<int> Create(Order order);
    }
}