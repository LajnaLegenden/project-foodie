using Microsoft.EntityFrameworkCore;
using project_foodie.Model;

namespace project_foodie.Repository;

public class DishRepository : RepositoryBase<Dish>, IDishRepository
{
    public DishRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<List<Dish>> GetAllAsync()
    {
        return await FindAll()
            .Include(d => d.Ingredients)
            .Include(d => d.Allergens)
            .ToListAsync();
    }

    public async Task<Dish> GetByIdAsync(int dishId)
    {
        return await FindByCondition(d => d.Id.Equals(dishId))
            .Include(d => d.Ingredients)
            .Include(d => d.Allergens)
            .FirstOrDefaultAsync();
    }

    public void AddDish(Dish dish)
    {
        Create(dish);
    }

    public void UpdateDish(Dish dish)
    {
        Update(dish);
    }

    public void DeleteDish(Dish dish)
    {
        Delete(dish);
    }

    public void AddIngredientToDish(Dish dish, Ingredient ingredient)
    {
        Console.WriteLine("[AddIngredientToDishAsync]: Trying to add " + ingredient.Name + " to menu " + dish.Name +
                          "");

        //if dish.Ingredients is null, create new list
        if (dish.Ingredients == null) dish.Ingredients = new List<Ingredient>();

        dish.Ingredients.Add(ingredient);
    }

    public void AddAllergenToDish(Dish dish, Allergen allergen)
    {
        Console.WriteLine("[AddallergenToDishAsync]: Trying to add " + allergen.Name + " to menu " + dish.Name + "");

        //if dish.allergens is null, create new list
        if (dish.Allergens == null) dish.Allergens = new List<Allergen>();

        dish.Allergens.Add(allergen);
    }
}