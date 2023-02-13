using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace project_foodie.Model;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required int userId { get; set; }
    public required Menu menu { get; set; }
    public required DateTime orderDate { get; set; }
    public ICollection<OrderItem> orderItems { get; set; }
}
