using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace project_foodie.Model;

public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required Order order { get; set; }
    public required Dish dish { get; set; }
    public required int quantity { get; set; }
    public DateTime date { get; set; }
    public OrderType type { get; set; }
}