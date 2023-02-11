using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace project_foodie.Model;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required int userId { get; set; }
    public required int menuId { get; set; }
    public required DateTime orderDate { get; set; }
    public IList<OrderItemOrder> OrderItemOrder { get; set; }
    public IList<DishOrder> DishOrder { get; set; }
}
