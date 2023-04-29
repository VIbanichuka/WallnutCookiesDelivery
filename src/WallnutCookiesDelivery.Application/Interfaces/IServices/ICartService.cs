using WallnutCookiesDelivery.Core.Entities;

namespace WallnutCookiesDelivery.Application.Interfaces.IServices;

public interface ICartService
{
    Cart GetCartByUserName(string userName);
    void AddItemToCart(string userName, int productId, int quantity);
    void RemoveCartItem(int cartId, int cartItemId);
    void UpdateCartItemQuantity(int cartId, int cartItemId, int quantity);
    void ClearCart(string userName);

}
