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
}
