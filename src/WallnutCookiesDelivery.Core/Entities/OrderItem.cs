using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WallnutCookiesDelivery.Core.Entities;

public class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    [Column(TypeName = "money")]
    [Required]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "money")]
    [Required]
    public decimal TotalPrice { get; set; }
    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }

}
