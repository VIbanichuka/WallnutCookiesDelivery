using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Web.Models;
using WallnutCookiesDelivery.Web.ViewModels;

namespace WallnutCookiesDelivery.Web.Controllers;

public class MenuController : Controller
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;
    public MenuController(IMapper mapper, IProductService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public IActionResult Index(MenuViewModel model)
    {
        var menuItems = _service.GetAllProduct();
        model.Products = _mapper.Map<List<ProductModel>>(menuItems);
        return View(model);
    }
}
