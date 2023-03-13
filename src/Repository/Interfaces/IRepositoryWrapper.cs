namespace project_foodie.Repository;

public interface IRepositoryWrapper
{
    IOrderRepository Order { get; }
    IMenuRepository Menu { get; }
    IDishRepository Dish { get; }
    IIngredientRepository Ingredient { get; }
    IAllergenRepository Allergen { get; }
    Task SaveAsync();
}