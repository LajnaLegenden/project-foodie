using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_foodie.Model;

public class Allergen
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Name { get; set; }

    public ICollection<Dish> Dishes { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
}