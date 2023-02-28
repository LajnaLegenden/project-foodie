using project_foodie.Model;

namespace project_foodie.Repository
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
    
        Task<List<Order>> GetAllAsync();
        List<Order> GetPage(int page, int pageSize);
        int GetNumberOfOrders();
        Task<Order> GetByIdAsync(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        void AddOrderItem(Order order, Dish dish, int quantity, DateTime date, OrderType type);
    }
}