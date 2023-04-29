using WallnutCookiesDelivery.Web.Models;

namespace WallnutCookiesDelivery.Web.ViewModels;

public class CartViewModel
{
    public CartViewModel()
    {
        CartItems = new List<CartItemsModel>();
        CartItem = new CartItemsModel();
    }
    public List<CartItemsModel> CartItems { get; set; }
    public CartItemsModel CartItem{get; set;}
}
