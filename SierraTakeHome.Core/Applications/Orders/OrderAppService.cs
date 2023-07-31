using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Orders;

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

        public async Task<int> Create(OrderDTO dto)
        {
            var order = new Order { 
                CustomerID = dto.CustomerID,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            return await _repository.Orders.Create(order);
        }
    }
}