using WallnutCookiesDelivery.Core.Entities;
using WallnutCookiesDelivery.Web.Models;

namespace WallnutCookiesDelivery.Web.ViewModels;

public class CartViewModel
{
    public CartViewModel()
    {
        CartItems = new List<CartItemsModel>();
        Cart = new CartModel();
        CartItem = new CartItemsModel();
    }
    public List<CartItemsModel> CartItems { get; set; }
    public CartItemsModel CartItem { get; set; }
    public CartModel Cart{get; set;}
}
