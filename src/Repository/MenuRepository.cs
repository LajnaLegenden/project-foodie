using Microsoft.EntityFrameworkCore;
using project_foodie.Model;

namespace project_foodie.Repository;

public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
{
    public MenuRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await FindAll()
            .OrderBy(m => m.startDate)
            .Include(m => m.dayMenus)
            .ThenInclude(dm => dm.dishes)
            .ThenInclude(d => d.Allergens)
            .ToListAsync();
    }

    public async Task<Menu> GetByIdAsync(int menuId)
    {
        return await FindByCondition(menu => menu.Id.Equals(menuId))
            .Include(m => m.dayMenus)
            .ThenInclude(dm => dm.dishes)
            .ThenInclude(d => d.Allergens)
            .FirstOrDefaultAsync();
    }

    public void AddMenu(Menu menu)
    {
        Create(menu);
    }

    public void UpdateMenu(Menu menu)
    {
        Update(menu);
    }

    public void DeleteMenu(Menu menu)
    {
        Delete(menu);
    }

    // Create orderItem and add to order
    public void AddDayMenu(Menu menu, DateTime date, Dish dish, OrderType orderType)
    {
        Console.WriteLine("[AddDayMenuAsync]: Trying to add " + dish.Name + " to menu " + menu.Name + " on " + date +
                          " for " + orderType + "");

        //if menu.dayMenus is null, create new list
        if (menu.dayMenus == null) menu.dayMenus = new List<DayMenu>();

        //if daymenu for that date already exists add dish to existing daymenu
        foreach (var day in menu.dayMenus)
            if (day.date == date && day.type == orderType)
            {
                day.dishes.Add(dish);
                return;
            }

        //if daymenu for that date does not exist create new daymenu and add dish
        var dayMenu = new DayMenu();
        dayMenu.date = date;
        dayMenu.dishes.Add(dish);
        dayMenu.type = orderType;
        menu.dayMenus.Add(dayMenu);
    }
}