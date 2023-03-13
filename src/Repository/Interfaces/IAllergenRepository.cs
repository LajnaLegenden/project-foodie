using project_foodie.Model;

namespace project_foodie.Repository;

public interface IAllergenRepository : IRepositoryBase<Allergen>
{
    Task<List<Allergen>> GetAllAsync();
    Task<Allergen> GetByIdAsync(int allergenId);
    Task<Allergen> GetByNameAsync(string name);
    void AddAllergen(Allergen allergen);
    void UpdateAllergen(Allergen allergen);
    void DeleteAllergen(Allergen allergen);
}