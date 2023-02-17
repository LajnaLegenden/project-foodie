using Microsoft.EntityFrameworkCore;
using project_foodie.Model;
namespace project_foodie.Repository;
public class DishRepository
{
    private readonly DatabaseContext _context;

    public DishRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Dish> GetByIdAsync(int id)
    {
        return await _context.Dishes.Include(d => d.Ingredients).Include(d => d.Allergens).FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Dish dish)
    {
        _context.Dishes.Add(dish);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Dish dish)
    {
        _context.Dishes.Update(dish);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Dish dish)
    {
        _context.Dishes.Remove(dish);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Dish>> GetAllAsync()
    {
        return await _context.Dishes.Include(d => d.Ingredients).Include(d => d.Allergens).ToListAsync();
    }

    public async Task AddAllergenToDishAsync(Dish dish, int allergenId)
    {
        Allergen allergen = _context.Allergens.FirstOrDefault(a => a.Id == allergenId);

        Console.WriteLine("[AddIngredientToDishAsync]: Trying to add " + allergen.Name + " to menu " + dish.Name + "");
        //if dish.Allergens is null, create new list
        if (dish.Allergens == null)
        {
            dish.Allergens = new List<Allergen>();
        }

        dish.Allergens.Add(allergen);
        await _context.SaveChangesAsync();
    }

    public async Task AddIngredientToDishAsync(Dish dish, int ingredientId)
    {
        Ingredient ingredient = _context.Ingredients.FirstOrDefault(a => a.Id == ingredientId);

        Console.WriteLine("[AddIngredientToDishAsync]: Trying to add " + ingredient.Name + " to menu " + dish.Name + "");
        //if dish.Ingredients is null, create new list
        if (dish.Ingredients == null)
        {
            dish.Ingredients = new List<Ingredient>();
        }

        dish.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Ingredient>> getDishIngredients(int id)
    {
        return (await _context.Dishes.Include(d => d.Ingredients).FirstOrDefaultAsync(d => d.Id == id)).Ingredients;
    }

    public async Task<ICollection<Allergen>> getDishAllergens(int id)
    {
        return (await _context.Dishes.Include(d => d.Allergens).FirstOrDefaultAsync(d => d.Id == id)).Allergens;

    }
}
