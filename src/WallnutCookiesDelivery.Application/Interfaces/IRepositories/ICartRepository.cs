using WallnutCookiesDelivery.Core.Entities;
namespace WallnutCookiesDelivery.Application.Interfaces.IRepositories;

public interface ICartRepository
{
    void AddItem(int productId, int quantity = 1, decimal unitPrice = 0);
    void RemoveItem(int cartItemId);
    void RemoveItemWithProduct(int productId);
    void ClearItem();
    Cart GetCart();
}
