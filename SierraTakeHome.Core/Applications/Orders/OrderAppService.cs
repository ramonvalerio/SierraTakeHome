using SierraTakeHome.Core.Models.Orders;

namespace SierraTakeHome.Core.Applications.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _repository;

        public OrderAppService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Order> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> Create(Order order)
        {
            return await _repository.Create(order);
        }
    }
}