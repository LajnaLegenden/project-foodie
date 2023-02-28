using Microsoft.EntityFrameworkCore;
using project_foodie.Model;

namespace project_foodie.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(o => o.orderDate)
                .Include(o => o.orderItems)
                .ThenInclude(o => o.dish)
                .Include(o => o.menu)
                .ToListAsync();
        }
        public List<Order> GetPage(int page, int pageSize)
        {
            return FindAll()
                .OrderBy(o => o.orderDate)
                .Include(o => o.orderItems)
                .ThenInclude(o => o.dish)
                .Include(o => o.menu)
                .ToList()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await FindByCondition(order => order.Id.Equals(orderId))
            .Include(o => o.orderItems)
            .Include(o => o.menu)
            .FirstOrDefaultAsync();
        }
        public void AddOrder(Order order)
        {
            Create(order);
        }
        public void UpdateOrder(Order order)
        {
            Update(order);
        }
        public void DeleteOrder(Order order)
        {
            Delete(order);
        }
        // Create orderItem and add to order
        public void AddOrderItem(Order order, Dish dish, int quantity, DateTime date, OrderType type)
        {
            //if order.orderItems is null, create new list
            if (order.orderItems == null)
            {
                order.orderItems = new List<OrderItem>();
            }

            OrderItem orderItem = new OrderItem()
            {
                order = order,
                dish = dish,
                quantity = quantity,
                date = date,
                type = type
            };
            order.orderItems.Add(orderItem);
        }

        public int GetNumberOfOrders()
        {
            return FindAll().Count();
        }
    }
}
