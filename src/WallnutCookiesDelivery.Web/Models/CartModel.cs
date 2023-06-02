namespace WallnutCookiesDelivery.Web.Models;

public class CartModel
{
    public int CartId { get; set; }
    public string UserName { get; set; }
    public List<CartItemsModel> CartItems { get; set; }
}