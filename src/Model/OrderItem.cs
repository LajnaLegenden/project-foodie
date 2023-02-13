using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace project_foodie.Model;

public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required int orderItemId { get; set; }
    public required int orderId { get; set; }
    public required int quantity { get; set; }

    public ICollection<Order> Orders { get; set; }
}