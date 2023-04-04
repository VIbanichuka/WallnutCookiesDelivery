using WallnutCookiesDelivery.Application.Interfaces.IRepositories;
using WallnutCookiesDelivery.Core.Entities;
using WallnutCookiesDelivery.DataAccess.Data;

namespace WallnutCookiesDelivery.DataAccess.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;
    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void AddItem(int productId, int quantity = 1, decimal unitPrice = 0)
    {
        throw new NotImplementedException();
    }

    public void ClearItem()
    {
        throw new NotImplementedException();
    }

    public Cart GetCart()
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(int cartItemId)
    {
        throw new NotImplementedException();
    }

    public void RemoveItemWithProduct(int productId)
    {
        throw new NotImplementedException();
    }
}