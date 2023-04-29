using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WallnutCookiesDelivery.Core.Entities;

public class Product
{
    public Product()
    {
        CartItems = new HashSet<CartItem>();
        OrderItems = new HashSet<OrderItem>();
    }
    public int ProductId { get; set; }

    [StringLength(50)]
    [Required]
    public string Name { get; set; }

    [Column(TypeName = "money")]
    [Required]
    public decimal Price { get; set; }

    [Column(TypeName = "ntext")]
    [StringLength(50)]
    [Required]
    public string Description { get; set; }

    [MaxLength(200)]
    [Required]
    public string ImageUrl { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; }

     public virtual ICollection<OrderItem> OrderItems { get; set; }
    
}