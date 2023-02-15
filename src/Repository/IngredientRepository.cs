using Microsoft.EntityFrameworkCore;
using project_foodie.Model;
namespace project_foodie.Repository;
public class IngredientRepository
{
    private readonly DatabaseContext _context;

    public IngredientRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Ingredient> GetByIdAsync(int id)
    {
        return await _context.Ingredients.Include(i => i.Allergens).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Ingredient> GetByName(string name)
    {
        return await _context.Ingredients.Include(i => i.Allergens).FirstOrDefaultAsync(i => i.Name == name);
    }

    public async Task AddAsync(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ingredient ingredient)
    {
        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await _context.Ingredients.Include(i => i.Allergens).ToListAsync();
    }

    public async Task AddAllergenToIngredientAsync(Ingredient ingredient, int allergenId)
    {
        Allergen allergen = _context.Allergens.FirstOrDefault(a => a.Id == allergenId);

        Console.WriteLine("[AddIngredientToDishAsync]: Trying to add " + allergen.Name + " to menu " + ingredient.Name + "");
        //if dish.Allergens is null, create new list
        if (ingredient.Allergens == null)
        {
            ingredient.Allergens = new List<Allergen>();
        }

        ingredient.Allergens.Add(allergen);
        await _context.SaveChangesAsync();
    }
}
