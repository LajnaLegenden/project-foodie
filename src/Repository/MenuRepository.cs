using Microsoft.EntityFrameworkCore;
using project_foodie.Model;

namespace project_foodie.Repository;

public class MenuRepository
{
    private readonly DatabaseContext _context;

    public MenuRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Menu> GetByIdAsync(int id)
    {
        return await _context.Menus.Include(m => m.dayMenus).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Menu menu)
    {
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Menu menu)
    {
        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await _context.Menus.Include(m => m.dayMenus).ThenInclude(dm => dm.dishes).ThenInclude(d => d.Allergens)
            .ToListAsync();
    }

    //Add daymenu to menu
    public async Task AddDayMenuAsync(Menu menu, DateTime date, Dish dish, OrderType orderType)
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
                await _context.SaveChangesAsync();
                return;
            }

        //if daymenu for that date does not exist create new daymenu and add dish
        var dayMenu = new DayMenu();
        dayMenu.date = date;
        dayMenu.dishes.Add(dish);
        dayMenu.type = orderType;
        menu.dayMenus.Add(dayMenu);
        await _context.SaveChangesAsync();
    }
}