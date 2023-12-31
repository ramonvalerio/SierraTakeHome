﻿namespace SierraTakeHome.Core.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<int> Create(Order order);
    }
}