using Microsoft.EntityFrameworkCore;
using project_foodie.Model;
namespace project_foodie.Repository;

public class MenuRepository
{
    private readonly DatabaseContext _context;

    public MenuRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Menu> GetByIdAsync(int id)
    {
        return await _context.Menus.Include(m => m.dayMenus).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Menu menu)
    {
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Menu menu)
    {
        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await _context.Menus.Include(m => m.dayMenus).ToListAsync();
    }

}
