using WallnutCookiesDelivery.Core.Entities;
using WallnutCookiesDelivery.Web.Models;

namespace WallnutCookiesDelivery.Web.ViewModels;

public class CartViewModel
{
    public CartViewModel()
    {
        CartItem = new CartItemsModel();
        Cart = new CartModel();
    }
    public CartItemsModel CartItem { get; set; }
    public CartModel Cart { get; set; }
}