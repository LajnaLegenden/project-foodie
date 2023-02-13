using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace project_foodie.Model;


public class Dish
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public FoodType Type { get; set; } = FoodType.Unknown;
    public string description { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public int Price { get; set; } = -1;
    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<Allergen> Allergens { get; set; }
    public ICollection<Menu> Menus { get; set; }
    public ICollection<Order> Orders { get; set; }



    public static async Task<Dish> GetDishByIdAsync(int id)
    {
        return (await Dish.GetAll()).Find(d => d.Id == id);

    }

    public static async Task<List<Dish>> GetAll()
    {
        using var context = new DatabaseContext();
        return await context.Dishes
            .Include(d => d.Ingredients).ThenInclude(i => i.Allergens)
            .Include(d => d.Allergens)
            .ToListAsync();
    }

}

