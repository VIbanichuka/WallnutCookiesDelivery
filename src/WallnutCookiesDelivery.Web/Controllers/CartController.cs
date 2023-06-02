using System.Diagnostics;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Web.ViewModels;

namespace WallnutCookiesDelivery.Web.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IMapper _mapper;
    public CartController(ICartService cartService, IMapper mapper)
    {
        _cartService = cartService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index(CartViewModel cartModel)
    {

        return View(cartModel);
    }

    [HttpPost]
    public IActionResult AddItemToCart(CartViewModel cartModel)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.Email);
        cartModel.Cart.UserName = claim.Value;

        _cartService.AddItemToCart(cartModel.Cart.UserName, cartModel.CartItem.Product.ProductId, cartModel.CartItem.Quantity);

        return Ok();
    }
}
