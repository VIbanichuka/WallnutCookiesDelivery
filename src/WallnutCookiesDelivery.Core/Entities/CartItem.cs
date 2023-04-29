using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WallnutCookiesDelivery.Core.Entities;

public class CartItem
{
    [Key]
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    [Column(TypeName = "money")]
    [Required]
    public decimal UnitPrice { get; set; }

    public virtual Product Product { get; set; } = null!;
    public virtual Cart Cart { get; set; } = null!;
}
