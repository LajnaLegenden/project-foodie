using project_foodie.Model;

namespace project_foodie.Repository;

public interface IDishRepository : IRepositoryBase<Dish>
{
    Task<List<Dish>> GetAllAsync();
    Task<Dish> GetByIdAsync(int dishId);
    void AddDish(Dish dish);
    void UpdateDish(Dish dish);
    void DeleteDish(Dish dish);
    void AddIngredientToDish(Dish dish, Ingredient ingredient);
    void AddAllergenToDish(Dish dish, Allergen allergen);
}