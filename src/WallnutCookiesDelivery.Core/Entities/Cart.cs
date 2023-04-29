using System.ComponentModel.DataAnnotations;

namespace WallnutCookiesDelivery.Core.Entities;

public class Cart
{
    public Cart()
    {
        CartItems = new HashSet<CartItem>();
    }
    [Key]
    public int CartId { get; set; }
    public string UserName { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
}