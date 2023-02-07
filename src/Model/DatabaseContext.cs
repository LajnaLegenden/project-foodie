using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
        optionsBuilder.UseSqlite("Data Source=/data/foodie/sqlite.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // AllergenIngredient
        modelBuilder.Entity<AllergenIngredient>().HasKey(ai => new { ai.AllergenId, ai.IngredientId });

        modelBuilder.Entity<AllergenIngredient>()
            .HasOne<Allergen>(ai => ai.Allergen)
            .WithMany(a => a.AllergenIngredient)
            .HasForeignKey(ai => ai.AllergenId);


        modelBuilder.Entity<AllergenIngredient>()
            .HasOne<Ingredient>(ai => ai.Ingredient)
            .WithMany(i => i.AllergenIngredient)
            .HasForeignKey(ai => ai.IngredientId);


        //Ingredent Dish
        modelBuilder.Entity<IngredientDish>().HasKey(id => new { id.IngredientId, id.DishId });
        modelBuilder.Entity<IngredientDish>()
            .HasOne<Ingredient>(id => id.Ingredient)
            .WithMany(i => i.IngredientDish)
            .HasForeignKey(id => id.IngredientId);
        modelBuilder.Entity<IngredientDish>()
            .HasOne<Dish>(id => id.Dish)
            .WithMany(d => d.IngredientDish)
            .HasForeignKey(id => id.DishId);

        //Allergen Dish
        modelBuilder.Entity<AllergenDish>().HasKey(ad => new { ad.AllergenId, ad.DishId });

        modelBuilder.Entity<AllergenDish>()
            .HasOne<Allergen>(ad => ad.Allergen)
            .WithMany(a => a.AllergenDish)
            .HasForeignKey(ad => ad.AllergenId);

        modelBuilder.Entity<AllergenDish>()
            .HasOne<Dish>(ad => ad.Dish)
            .WithMany(d => d.AllergenDish)
            .HasForeignKey(ad => ad.DishId);

        //Dish Menu
        modelBuilder.Entity<DishMenu>().HasKey(dm => new { dm.MenuId, dm.DishId });

        modelBuilder.Entity<DishMenu>()
            .HasOne<Menu>(dm => dm.Menu)
            .WithMany(d => d.DishMenu)
            .HasForeignKey(dm => dm.MenuId);

        modelBuilder.Entity<DishMenu>()
            .HasOne<Dish>(dm => dm.Dish)
            .WithMany(m => m.DishMenu)
            .HasForeignKey(dm => dm.DishId);
        // OrderItem Order
        modelBuilder.Entity<OrderItemOrder>().HasKey(oio => new { oio.OrderItemId, oio.OrderId });

        modelBuilder.Entity<OrderItemOrder>()
            .HasOne<OrderItem>(oio => oio.OrderItem)
            .WithMany(oi => oi.OrderItemOrder)
            .HasForeignKey(oio => oio.OrderItemId);


        modelBuilder.Entity<OrderItemOrder>()
            .HasOne<Order>(oio => oio.Order)
            .WithMany(o => o.OrderItemOrder)
            .HasForeignKey(oio => oio.OrderId);

        // Dish Order
        modelBuilder.Entity<DishOrder>().HasKey(dio => new { dio.DishId, dio.OrderId });

        modelBuilder.Entity<DishOrder>()
            .HasOne<Dish>(dio => dio.Dish)
            .WithMany(d => d.DishOrder)
            .HasForeignKey(dio => dio.DishId);


        modelBuilder.Entity<DishOrder>()
            .HasOne<Order>(dio => dio.Order)
            .WithMany(o => o.DishOrder)
            .HasForeignKey(dio => dio.OrderId);

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
    Lunch, Dinner, Unknown
}


// Tables
public class Ingredient
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public IList<IngredientDish> IngredientDish { get; set; }
    public IList<AllergenIngredient> AllergenIngredient { get; set; }
}

public class Allergen
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public IList<AllergenDish> AllergenDish { get; set; }
    public IList<AllergenIngredient> AllergenIngredient { get; set; }
}

public class Dish
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public FoodType Type { get; set; } = FoodType.Unknown;
    public string description { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public int Price { get; set; } = -1;
    public IList<IngredientDish> IngredientDish { get; set; }
    public IList<AllergenDish> AllergenDish { get; set; }
    public IList<DishMenu> DishMenu { get; set; }
    public IList<DishOrder> DishOrder { get; set; }

}

public class Menu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime lastOrderDate { get; set; }
    public required DateTime startDate { get; set; }
    public required DateTime endDate { get; set; }
    public IList<DishMenu> DishMenu { get; set; }
}

public class OrderItem
{

    public required DateTime date { get; set; }
    public required int id { get; set; }

    public OrderType type { get; set; } = OrderType.Unknown;

    public IList<OrderItemOrder> OrderItemOrder { get; set; }
}

public class Order
{
    public required int Id { get; set; }
    public required int userId { get; set; }
    public required int menuId { get; set; }
    public required DateTime orderDate { get; set; }
    public IList<OrderItemOrder> OrderItemOrder { get; set; }
    public IList<DishOrder> DishOrder { get; set; }

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
    public Dish Dish { get; set; }

    public int MenuId { get; set; }
    public Menu Menu { get; set; }
}


public class OrderItemOrder
{

    public int OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}

public class DishOrder
{

    public int DishId { get; set; }
    public Dish Dish { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}

