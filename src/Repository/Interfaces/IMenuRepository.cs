using project_foodie.Model;

namespace project_foodie.Repository;

public interface IMenuRepository : IRepositoryBase<Menu>
{
    Task<List<Menu>> GetAllAsync();
    Task<Menu> GetByIdAsync(int menuId);
    void AddMenu(Menu menu);
    void UpdateMenu(Menu menu);
    void DeleteMenu(Menu menu);
    void AddDayMenu(Menu menu, DateTime date, Dish dish, OrderType orderType);
}