using Microsoft.EntityFrameworkCore;
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

    public void Add(Cart cart)
    {
        _context.Carts.Add(cart);
        _context.SaveChanges();
    }

    public Cart GetCartByUserName(string userName)
    {
        return _context.Carts.FirstOrDefault(c => c.UserName == userName);
    }

    public void Remove(Cart cart)
    {
        _context.Carts.Remove(cart);
        _context.SaveChanges();
    }

    public void Update(Cart cart)
    {
        _context.Update(cart);
        _context.SaveChanges();
    }

    public Cart GetUserCart(string userName)
    {
        var cart = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                .Where(c => c.UserName == userName)
                .FirstOrDefault();
        return cart;
    }
}