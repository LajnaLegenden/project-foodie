using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public ICollection<DayMenu> dayMenus { get; set; } = new List<DayMenu>();
}