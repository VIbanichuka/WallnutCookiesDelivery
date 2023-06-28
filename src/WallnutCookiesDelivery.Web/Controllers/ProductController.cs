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
        if (products != null)
        {
            model.Products = _mapper.Map<List<ProductModel>>(products);
        }
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
        var newProduct = _mapper.Map<Product>(model.Product);
        _productService.Create(newProduct);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id, MenuViewModel model)
    {
        var existingProduct = _productService.GetProductById(id);
        if (existingProduct != null)
        {
            model.Product = _mapper.Map<ProductModel>(existingProduct);
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult EditProduct(MenuViewModel model, string imageUrl)
    {
        var existingProduct = _productService.GetProductById(model.Product.ProductId);
        model.Product.ImageUrl = _fileService.UpdateImage(model.Product.ImageFile, existingProduct.ImageUrl);
        _mapper.Map(model.Product, existingProduct);
        _productService.Update(existingProduct);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id, MenuViewModel model)
    {
        var productToDelete = _productService.GetProductById(id);
        if (productToDelete != null)
        {
            model.Product = _mapper.Map<ProductModel>(productToDelete);
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var productToDelete = _productService.GetProductById(id);
        if(productToDelete != null)
        {
            _fileService.DeleteImage(productToDelete.ImageUrl);
            _productService.Delete(productToDelete);
        }
        return RedirectToAction("Index");
    }
}