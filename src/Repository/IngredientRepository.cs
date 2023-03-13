using Microsoft.EntityFrameworkCore;
using project_foodie.Model;

namespace project_foodie.Repository;

public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
{
    public IngredientRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await FindAll()
            .Include(i => i.Allergens)
            .ToListAsync();
    }

    public async Task<Ingredient> GetByIdAsync(int ingredientId)
    {
        return await FindByCondition(i => i.Id.Equals(ingredientId))
            .Include(i => i.Allergens)
            .FirstOrDefaultAsync();
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Create(ingredient);
    }

    public void UpdateIngredient(Ingredient ingredient)
    {
        Update(ingredient);
    }

    public void DeleteIngredient(Ingredient ingredient)
    {
        Delete(ingredient);
    }

    public void AddAllergenToIngredient(Ingredient ingredient, Allergen allergen)
    {
        Console.WriteLine("[AddallergenToIngredientAsync]: Trying to add " + allergen.Name + " to menu " +
                          ingredient.Name + "");

        //if Ingredient.allergens is null, create new list
        if (ingredient.Allergens == null) ingredient.Allergens = new List<Allergen>();

        ingredient.Allergens.Add(allergen);
    }
}