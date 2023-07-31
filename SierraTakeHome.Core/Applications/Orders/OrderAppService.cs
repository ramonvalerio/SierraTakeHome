using SierraTakeHome.Core.Models.Orders;

namespace SierraTakeHome.Core.Applications.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderAppService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        Task<List<Order>> IOrderAppService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Order> IOrderAppService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}