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
        var cart = GetCartOrCreateCart(userName);
        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

        if (cartItem != null)
        {
            cartItem.Quantity += quantity;
        }
        else
        {
            cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = product.Price
            };
            cart.CartItems.Add(cartItem);
        }
        _cartRepository.Add(cart);
    }

    public void ClearCart(string userName)
    {
        var cart = _cartRepository.GetCartByUserName(userName);
        if (cart == null)
        {
            throw new ApplicationException("No cart found to clear");
        }
        cart.CartItems.Clear();
        _cartRepository.Update(cart);
    }

    public void RemoveCartItem(string userName, int cartItemId)
    {
        var cart = GetCartOrCreateCart(userName);
        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
        if (cartItem != null)
        {
            cart.CartItems.Remove(cartItem);
            _cartRepository.Update(cart);
        }
    }

    private Cart GetCartOrCreateCart(string userName)
    {
        var cart = _cartRepository.GetCartByUserName(userName);
        if (cart == null)
        {
            cart = new Cart
            {
                UserName = userName,
                CartItems = new List<CartItem>()
            };
            _cartRepository.Add(cart);
        }
        return cart;
    }

    public Cart GetUserCart(string userName)
    {
        return _cartRepository.GetUserCart(userName);
    }
}
