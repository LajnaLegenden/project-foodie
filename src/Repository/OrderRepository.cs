using Microsoft.EntityFrameworkCore;
using project_foodie.Model;
namespace project_foodie.Repository;

public class OrderRepository
{
    private readonly DatabaseContext _context;

    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders.Include(o => o.orderItems).Include(o => o.menu).FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.Include(o => o.orderItems).ThenInclude(oi => oi.dish).ToListAsync();
    }

}
