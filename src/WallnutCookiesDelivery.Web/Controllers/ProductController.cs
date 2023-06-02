using AutoMapper;
using WallnutCookiesDelivery.Web.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using WallnutCookiesDelivery.Web.Models;
using WallnutCookiesDelivery.Web.ViewModels;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WallnutCookiesDelivery.Web.Controllers;

[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    public ProductController(IMapper mapper, IProductService productService, IFileService fileService)
    {
        _mapper = mapper;
        _productService = productService;
        _fileService = fileService;
    }

    [HttpGet]
    public IActionResult Index(MenuViewModel model)
    {
        var products = _productService.GetAllProduct();
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
        var product = _mapper.Map<Product>(model.Product);
        _productService.Create(product);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id, MenuViewModel model)
    {
        var product = _productService.GetProductById(id);
        if (product != null)
        {
            model.Product = _mapper.Map<ProductModel>(product);
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult EditProduct(MenuViewModel model, string imageUrl)
    {
        var productDetails = _productService.GetProductById(model.Product.ProductId);
        imageUrl = productDetails.ImageUrl;
        model.Product.ImageUrl = _fileService.UpdateImage(model.Product.ImageFile, imageUrl);
        
        productDetails.Description = model.Product.Description;
        productDetails.Name = model.Product.Name;
        productDetails.Price = model.Product.Price;
        productDetails.ImageUrl = model.Product.ImageUrl;
        
        _productService.Update(productDetails);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id, MenuViewModel model)
    {
        var product = _productService.GetProductById(id);
        if (product != null)
        {
            model.Product = _mapper.Map<ProductModel>(product);
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _productService.GetProductById(id);
        _fileService.DeleteImage(product.ImageUrl);
        _productService.Delete(product);
        return RedirectToAction("Index");
    }
}