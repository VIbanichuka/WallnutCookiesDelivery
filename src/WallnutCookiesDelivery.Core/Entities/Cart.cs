namespace WallnutCookiesDelivery.Core.Entities;

public class Cart
{
    public Cart()
    {
        CartItems = new List<CartItem>();
    }
    public List<CartItem> CartItems { get; set; }
}
