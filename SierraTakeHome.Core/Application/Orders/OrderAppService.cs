﻿using SierraTakeHome.Core.Domain.Orders;
using SierraTakeHome.Core.Infrastructure.Data;

namespace SierraTakeHome.Core.Application.Orders
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

        public async Task<Order> Create(OrderCommand command)
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

            var orderId = await _repository.Orders.Create(order);

            return await _repository.Orders.GetById(orderId);
        }
    }
}