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

        public async Task Create(OrderCommand command)
        {
            if (command == null)
                throw new NullReferenceException("Argument reference is null.");

            command.IsValid();

            var product = await _repository.Products.GetById(command.ProductId);

            if (product == null)
                throw new Exception($"ProductId {command.ProductId} not found.");

            var order = new Order {
                CustomerId = command.CustomerId,
                ProductId = command.ProductId,
                Quantity = command.Quantity
            };

            await _repository.Orders.Create(order);
        }
    }
}