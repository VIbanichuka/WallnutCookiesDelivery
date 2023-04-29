using WallnutCookiesDelivery.Application.Interfaces.IRepositories;
using WallnutCookiesDelivery.Core.Entities;
using WallnutCookiesDelivery.DataAccess.Data;

namespace WallnutCookiesDelivery.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public Product GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.ProductId == id);
    }

    public List<Product> GetProductList()
    {
        return _context.Products.ToList();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
}
