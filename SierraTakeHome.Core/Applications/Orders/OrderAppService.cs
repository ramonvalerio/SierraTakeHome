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

        public async Task Create(OrderCommand dto)
        {
            dto.IsValid();

            var product = await _repository.Products.GetById(dto.ProductId);

            if (product == null)
                throw new Exception($"ProductId {dto.ProductId} not found.");

            var order = new Order {
                CustomerId = dto.CustomerId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            await _repository.Orders.Create(order);
        }
    }
}