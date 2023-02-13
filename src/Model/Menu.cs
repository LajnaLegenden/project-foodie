using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace project_foodie.Model;

public struct DayMenu {
    DateTime date;
    ICollection<int> dishes;
    FoodType type;
}

public class Menu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime lastOrderDate { get; set; }
    public required DateTime startDate { get; set; }
    public required DateTime endDate { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<DayMenu> dayMenus {get;set;}

    public static async Task<Menu> GetMenuByIdAsync(int id)
    {
        using (var _context = new DatabaseContext())
        {
            return (await _context.Menus.Include(m => m.Dishes).ToListAsync<Menu>()).Find(m => m.Id == id);
        }
    }

    public static List<Menu> GetAll()
    {
        using (var _context = new DatabaseContext())
        {

            return _context.Menus.Include(m => m.Dishes).ToList<Menu>();
        }
    }

    //Add a dish to the menu
    public static async Task<bool> AddDishToMenuAsync(int menuId, int dishId)
    {
        using (var _context = new DatabaseContext())
        {
            var menu = await Menu.GetMenuByIdAsync(menuId);
            var dish = await Dish.GetDishByIdAsync(dishId);
            if (menu != null && dish != null)
            {
                Console.WriteLine("Adding dish to menu");
                Console.WriteLine(menu.Name);
                Console.WriteLine(dish.Name);
                menu.Dishes.Add(dish);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}