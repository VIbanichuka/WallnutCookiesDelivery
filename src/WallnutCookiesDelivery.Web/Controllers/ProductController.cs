using AutoMapper;
using WallnutCookiesDelivery.Web.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using WallnutCookiesDelivery.Web.Models;
using WallnutCookiesDelivery.Web.ViewModels;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Core.Entities;

namespace WallnutCookiesDelivery.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _service;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    public ProductController(IMapper mapper, IProductService service, IFileService fileService)
    {
        _mapper = mapper;
        _service = service;
        _fileService = fileService;
    }

    [HttpGet]
    public IActionResult Index(MenuViewModel model)
    {
        var products = _service.GetAllProduct();
        model.Products = _mapper.Map<List<ProductModel>>(products);
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateProduct(MenuViewModel model)
    {
        model.Product.ImageUrl = _fileService.UploadImage(model.Product.ImageFile);
        var mapped = _mapper.Map<Product>(model.Product);
        _service.Create(mapped);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id, MenuViewModel model)
    {
        var product = _service.GetProductById(id);
        if (product != null)
        {
            model.Product = _mapper.Map<ProductModel>(product);
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult EditProduct(MenuViewModel model)
    {

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id, MenuViewModel model)
    {
        var product = _service.GetProductById(id);
        if (product != null)
        {
            model.Product = _mapper.Map<ProductModel>(product);
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _service.GetProductById(id);
        _fileService.DeleteImage(product.ImageUrl);
        _service.Delete(product);
        return RedirectToAction("Index");
    }
}