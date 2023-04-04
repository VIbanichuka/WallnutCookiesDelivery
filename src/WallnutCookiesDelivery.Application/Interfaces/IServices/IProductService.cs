using WallnutCookiesDelivery.Core.Entities;
namespace WallnutCookiesDelivery.Application.Interfaces.IServices;

public interface IProductService
{
    Product GetProductById(int id);
    List<Product> GetAllProduct();
    void Create(Product product);
    void Update(Product product);
    void Delete(Product product);
}
