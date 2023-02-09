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
    public IList<IngredientDish> IngredientDish { get; set; }
    public IList<AllergenDish> AllergenDish { get; set; }
    public IList<DishMenu> DishMenu { get; set; }
    public IList<DishOrder> DishOrder { get; set; }



    public static async Task<Dish> GetDishByIdAsync(int id)
    {
        using var context = new DatabaseContext();
        return (await context.Dishes.Include(d => d.IngredientDish).ThenInclude(id => id.Ingredient).Include(d => d.AllergenDish)!.ThenInclude(ad => ad.Allergen).ToListAsync<Dish>()).Find(d => d.Id == id);
    }

    public static List<Dish> GetAll()
    {
        using var context = new DatabaseContext();
        return context.Dishes.Include(d => d.IngredientDish).ThenInclude(id => id.Ingredient).Include(d => d.AllergenDish).ThenInclude(ad => ad.Allergen).ToList<Dish>();
    }

}

