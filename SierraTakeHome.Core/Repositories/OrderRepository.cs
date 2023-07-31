namespace SierraTakeHome.Core.Repositories
{
    using SierraTakeHome.Core.Models.Orders;
    //using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OrderRepository
    {
        //private readonly DbContext _context;

        //public OrderRepository(DbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IEnumerable<Order>> GetAllAsync()
        //{
        //    return await _context.Set<Order>().ToListAsync();
        //}

        //public async Task<Order> GetByIdAsync(int id)
        //{
        //    return await _context.Set<Order>().FindAsync(id);
        //}

        //public async Task CreateAsync(Order order)
        //{
        //    _context.Set<Order>().Add(order);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(Order order)
        //{
        //    _context.Set<Order>().Update(order);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var order = await GetByIdAsync(id);
        //    if (order != null)
        //    {
        //        _context.Set<Order>().Remove(order);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
