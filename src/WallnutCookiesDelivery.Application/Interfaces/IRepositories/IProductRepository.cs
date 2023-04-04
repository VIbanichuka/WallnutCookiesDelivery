using WallnutCookiesDelivery.Core.Entities;
namespace WallnutCookiesDelivery.Application.Interfaces.IRepositories;

public interface IProductRepository
{
    List<Product> GetProductList();
    Product GetProductById(int id);
    void Create(Product product);
    void Update(Product product);
    void Delete(Product product);
}
