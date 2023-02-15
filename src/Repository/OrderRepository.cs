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

    //Add orderItem to order
    public async Task AddOrderItemAsync(Order order, Dish dish, int quantity)
    {
        Console.WriteLine("[AddOrderItemAsync]: Trying to add new orderItem with dish " + dish.Name + " and order " + order.Id + " of quantity " + quantity.ToString() + "");
        //if order.orderitems is null, create new list
        if (order.orderItems == null)
        {
            order.orderItems = new List<OrderItem>();
        }
        //create OrderItem
        OrderItem orderItem = new OrderItem()
        {
            order = order,
            dish = dish,
            quantity = quantity
        };
        await _context.SaveChangesAsync();
    }

}
