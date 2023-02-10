namespace project_foodie.Model;

public class Ingredient
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public IList<IngredientDish> IngredientDish { get; set; }
    public IList<AllergenIngredient> AllergenIngredient { get; set; }
}
