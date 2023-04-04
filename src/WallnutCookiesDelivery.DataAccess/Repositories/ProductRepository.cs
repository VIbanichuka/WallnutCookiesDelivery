using WallnutCookiesDelivery.Application.Interfaces.IRepositories;
using WallnutCookiesDelivery.Core.Entities;
using WallnutCookiesDelivery.DataAccess.Data;

namespace WallnutCookiesDelivery.DataAccess.Repositories;


public class ProductRepository: IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    void IProductRepository.Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    void IProductRepository.Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    Product IProductRepository.GetProductById(int id)
    {
        return _context.Products.Find(id);
    }

    List<Product> IProductRepository.GetProductList()
    {
        return _context.Products.ToList();
    }

    void IProductRepository.Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
}
