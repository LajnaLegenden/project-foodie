namespace project_foodie.Model;

public class Allergen
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public IList<AllergenDish> AllergenDish { get; set; }
    public IList<AllergenIngredient> AllergenIngredient { get; set; }
}
