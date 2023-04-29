using WallnutCookiesDelivery.Application.Interfaces.IRepositories;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Core.Entities;

namespace WallnutCookiesDelivery.Application.Service;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public CartService(ICartRepository cartRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public void AddItemToCart(string userName, int productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public void ClearCart(string userName)
    {
        throw new NotImplementedException();
    }

    public Cart GetCartByUserName(string userName)
    {
        throw new NotImplementedException();
    }

    public void RemoveCartItem(int cartId, int cartItemId)
    {
        throw new NotImplementedException();
    }

    public void UpdateCartItemQuantity(int cartId, int cartItemId, int quantity)
    {
        throw new NotImplementedException();
    }
}
