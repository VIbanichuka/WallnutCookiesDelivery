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

    public void AddItemToCart(string userName, int productId, int quantity = 1)
    {
        var product = _productRepository.GetProductById(productId);
        var cart = _cartRepository.GetCartByUserName(userName);
        if (cart == null)
        {
            cart = new Cart(userName);
        }
        var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if(existingCartItem != null)
        {
            existingCartItem.Quantity++;
        }
        else
        {
            var newItem = new CartItem()
            {
                ProductId = product.ProductId,
                Quantity = quantity,
                UnitPrice = product.Price,
            };
            cart.CartItems.Add(newItem);
        }
        _cartRepository.Add(cart);
    }

    public void ClearCart(string userName)
    {
        throw new NotImplementedException();
    }

    public Cart GetUserCart(string userName)
    {
        return _cartRepository.GetCartByUserName(userName);
    }

    public void RemoveCartItem(string userName, int cartItemId)
    {
        throw new NotImplementedException();
    }
}