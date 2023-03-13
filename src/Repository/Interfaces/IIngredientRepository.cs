using project_foodie.Model;

namespace project_foodie.Repository;

public interface IIngredientRepository : IRepositoryBase<Ingredient>
{
    Task<List<Ingredient>> GetAllAsync();
    Task<Ingredient> GetByIdAsync(int ingredientId);
    void AddIngredient(Ingredient ingredient);
    void UpdateIngredient(Ingredient ingredient);
    void DeleteIngredient(Ingredient ingredient);
    void AddAllergenToIngredient(Ingredient Ingredient, Allergen allergen);
}