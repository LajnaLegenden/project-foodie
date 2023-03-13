using Microsoft.EntityFrameworkCore;
using project_foodie.Model;

namespace project_foodie.Repository;

public class AllergenRepository : RepositoryBase<Allergen>, IAllergenRepository
{
    public AllergenRepository(DatabaseContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<List<Allergen>> GetAllAsync()
    {
        return await FindAll()
            .ToListAsync();
    }

    public async Task<Allergen> GetByIdAsync(int allergenId)
    {
        return await FindByCondition(a => a.Id.Equals(allergenId))
            .FirstOrDefaultAsync();
    }

    public async Task<Allergen> GetByNameAsync(string name)
    {
        return await FindByCondition(a => a.Name.Equals(name))
            .FirstOrDefaultAsync();
    }

    public void AddAllergen(Allergen allergen)
    {
        Create(allergen);
    }

    public void UpdateAllergen(Allergen allergen)
    {
        Update(allergen);
    }

    public void DeleteAllergen(Allergen allergen)
    {
        Delete(allergen);
    }
}