using WallnutCookiesDelivery.Core.Entities;

namespace WallnutCookiesDelivery.Application.Interfaces.IServices;

public interface ICartService
{
    void AddItemToCart(string userName, int productId, int quantity);
    void RemoveCartItem(string userName, int cartItemId);
    void ClearCart(string userName);
    Cart GetUserCart(string userName);
}
