using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace project_foodie.Model;

public class DayMenu {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    DateTime date{ get; set; }
    ICollection<Dish> dishes{ get; set; }
    FoodType type{ get; set; }
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
    public ICollection<DayMenu> dayMenus {get;set;}
}