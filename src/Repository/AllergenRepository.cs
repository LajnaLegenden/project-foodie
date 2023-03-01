using Microsoft.EntityFrameworkCore;
using project_foodie.Model;

namespace project_foodie.Repository;

public class AllergenRepository
{
    private readonly DatabaseContext _context;

    public AllergenRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Allergen> GetByIdAsync(int id)
    {
        return await _context.Allergens.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Allergen> GetByName(string name)
    {
        return await _context.Allergens.FirstOrDefaultAsync(d => d.Name == name);
    }

    public async Task AddAsync(Allergen allergen)
    {
        _context.Allergens.Add(allergen);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Allergen allergen)
    {
        _context.Allergens.Update(allergen);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Allergen allergen)
    {
        _context.Allergens.Remove(allergen);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Allergen>> GetAllAsync()
    {
        return await _context.Allergens.ToListAsync();
    }
}