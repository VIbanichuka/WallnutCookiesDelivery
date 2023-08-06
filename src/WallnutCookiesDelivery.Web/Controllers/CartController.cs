using System.Diagnostics;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Core.Entities;
using WallnutCookiesDelivery.Web.Models;
using WallnutCookiesDelivery.Web.ViewModels;

namespace WallnutCookiesDelivery.Web.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public CartController(ICartService cartService, IMapper mapper, IProductService productService)
    {
        _cartService = cartService;
        _mapper = mapper;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Index(CartViewModel cartViewModel)
    {
        return View(cartViewModel);
    }

    [HttpPost]
    public IActionResult AddItemToCart(CartViewModel cartModel)
    {
        var claimsIdentity = (ClaimsIdentity?)User.Identity;
        var claim = claimsIdentity?.FindFirst(ClaimTypes.Email);
        
        
        return RedirectToAction("Index");
    }
}