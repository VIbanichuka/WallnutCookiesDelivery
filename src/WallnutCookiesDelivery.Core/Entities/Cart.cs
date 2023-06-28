using System.ComponentModel.DataAnnotations;

namespace WallnutCookiesDelivery.Core.Entities;

public class Cart
{
    public Cart(string userName)
    {
        CartItems = new HashSet<CartItem>();
        UserName = userName;
    }
    [Key]
    public int CartId { get; set; }
    public string UserName { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
}