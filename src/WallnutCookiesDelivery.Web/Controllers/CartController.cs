using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Web.ViewModels;

namespace WallnutCookiesDelivery.Web.Controllers;

public class CartController: Controller
{
    private readonly ICartService _cartService;
    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    [HttpGet]
    public IActionResult Index(CartViewModel cartModel)
    {
        return View(cartModel);
    }
    
    [HttpPost]
    public IActionResult AddItemToCart(CartViewModel cartModel)
    {
        cartModel.CartItem.Id = 0;
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        cartModel.CartItem.UserId = claim.Value;

    
        return View();
    }
}
