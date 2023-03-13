// Wrapper for all repositories, all other repositories should be accessed from this wrapper.
// ex: repository = new RepositoryWrapper(db)
//     repository.Order.getAllAsync()

using project_foodie.Model;

namespace project_foodie.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DatabaseContext _dbContext;
    private IOrderRepository _order;
    private IMenuRepository _menu;
    private IDishRepository _dish;
    private IIngredientRepository _ingredient;
    private IAllergenRepository _allergen;


    public RepositoryWrapper(DatabaseContext databaseContext)
    {
        _dbContext = databaseContext;
    }

    public IOrderRepository Order
    {
        get
        {
            if (_order == null) _order = new OrderRepository(_dbContext);

            return _order;
        }
    }

    public IMenuRepository Menu
    {
        get
        {
            if (_menu == null) _menu = new MenuRepository(_dbContext);

            return _menu;
        }
    }

    public IDishRepository Dish
    {
        get
        {
            if (_dish == null) _dish = new DishRepository(_dbContext);

            return _dish;
        }
    }

    
    public IIngredientRepository Ingredient
    {
        get
        {
            if (_ingredient == null) _ingredient = new IngredientRepository(_dbContext);

            return _ingredient;
        }
    }

    public IAllergenRepository Allergen
    {
        get
        {
            if (_allergen == null) _allergen = new AllergenRepository(_dbContext);

            return _allergen;
        }
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}