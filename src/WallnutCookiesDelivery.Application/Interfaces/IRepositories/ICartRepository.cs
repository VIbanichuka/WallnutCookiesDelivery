using WallnutCookiesDelivery.Core.Entities;
namespace WallnutCookiesDelivery.Application.Interfaces.IRepositories;

public interface ICartRepository
{
    void Add(Cart cart);
    void Remove(Cart cart);
    void Update(Cart cart);
    Cart GetCartByUserName(string userName);
    Cart GetUserCart(string userName);
}
