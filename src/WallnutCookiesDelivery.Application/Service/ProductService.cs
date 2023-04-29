
using WallnutCookiesDelivery.Application.Interfaces.IRepositories;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Core.Entities;

namespace WallnutCookiesDelivery.Application.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Create(Product product)
    {
        _productRepository.Create(product);
    }

    public void Delete(Product product)
    {
        _productRepository.Delete(product);
    }

    public List<Product> GetAllProduct()
    {
        return _productRepository.GetProductList();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void Update(Product product)
    {
        _productRepository.Update(product);
    }
}
