using SierraTakeHome.Core.Domain.Orders;

namespace SierraTakeHome.Core.Application.Orders
{
    public interface IOrderAppService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> Create(OrderCommand dto);
    }
}