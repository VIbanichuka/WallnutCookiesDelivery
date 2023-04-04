using WallnutCookiesDelivery.Core.Entities;
namespace WallnutCookiesDelivery.Application.Interfaces.IRepositories;

public interface IOrderRepository
{
    List<Order> GetOrderById(int id); 
}
