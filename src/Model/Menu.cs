using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_foodie.Model;

public class DayMenu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime date { get; set; }
    public ICollection<Dish> dishes { get; set; } = new List<Dish>();
    public OrderType type { get; set; }
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
    public ICollection<DayMenu> dayMenus { get; set; }
    public ICollection<Order> Order { get; set; }
}