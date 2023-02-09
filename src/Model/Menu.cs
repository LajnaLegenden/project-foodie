using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace project_foodie.Model;

public class Menu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime lastOrderDate { get; set; }
    public required DateTime startDate { get; set; }
    public required DateTime endDate { get; set; }
    public IList<DishMenu> DishMenu { get; set; }

    public static async Task<Menu> GetMenuByIdAsync(int id)
    {
        using (var _context = new DatabaseContext())
        {

            return (await _context.Menus.Include(m => m.DishMenu).ThenInclude(dm => dm.Dish).ToListAsync<Menu>()).Find(m => m.Id == id);
        }
    }

    public static List<Menu> GetAll()
    {
        using (var _context = new DatabaseContext())
        {

            return _context.Menus.Include(m => m.DishMenu).ThenInclude(dm => dm.Dish).ToList<Menu>();
        }
    }

    //Add a dish to the menu
    public static void AddDishToMenu(int menuId, int dishId)
    {
        using (var _context = new DatabaseContext())
        {
            var dishMenu = new DishMenu();
            dishMenu.DishId = dishId;
            dishMenu.MenuId = menuId;
            _context.DishMenu.Add(dishMenu);
            _context.SaveChanges();
        }
    }
}