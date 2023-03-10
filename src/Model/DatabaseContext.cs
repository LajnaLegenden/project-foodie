using System.ComponentModel.DataAnnotations;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace project_foodie.Model;

public class DatabaseContext : DbContext
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Allergen> Allergens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();
        var dbAddr = Environment.GetEnvironmentVariable("DBADDR");
        var dbUser = Environment.GetEnvironmentVariable("DBUSER");
        var dbName = Environment.GetEnvironmentVariable("DBNAME");
        var dbPass = Environment.GetEnvironmentVariable("DBPASS");
        var connectionString = $"server={dbAddr};user={dbUser};database={dbName};password={dbPass};";
        var serverVersion = new MariaDbServerVersion(new Version(10, 6, 11));

        optionsBuilder.UseMySql(connectionString, serverVersion).LogTo(Console.WriteLine, LogLevel.Error);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

public enum FoodType
{
    Chicken,
    Beef,
    Pork,
    Fish,
    Vegetarian,
    Vegan,
    Unknown
}

public enum OrderType
{
    Lunch,
    Middag,
    Unknown
}

public class OrderItemOrder
{
    public int OrderItemId { get; set; }

    // The OrderItem property is used to access the OrderItem class and its methods.
    // The OrderItem class is used to store information about an order item.
    [Required] public OrderItem OrderItem { get; set; }


    public int OrderId { get; set; }

    [Required] public Order Order { get; set; }
}

// connection tables
public class AllergenIngredient
{
    public int AllergenId { get; set; }
    public Allergen Allergen { get; set; }

    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}

public class IngredientDish
{
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; }
}

public class AllergenDish
{
    public int AllergenId { get; set; }
    public Allergen Allergen { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; }
}

public class DishMenu
{
    public int DishId { get; set; }

    [JsonIgnore] public Dish Dish { get; set; }

    public int MenuId { get; set; }

    [JsonIgnore] public Menu Menu { get; set; }
}

public class DishOrder
{
    public int DishId { get; set; }
    public Dish Dish { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}