using SierraTakeHome.Core.Models.Orders;
using SierraTakeHome.Core.Repositories;

namespace SierraTakeHome.Core.Applications.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IUnitOfWork _repository;

        public OrderAppService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _repository.Orders.GetAll();
        }

        public async Task<Order> GetById(int id)
        {
            return await _repository.Orders.GetById(id);
        }

        public async Task<int> Create(Order order)
        {
            return await _repository.Orders.Create(order);
        }
    }
}