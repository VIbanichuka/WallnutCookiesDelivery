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

    public Cart GetCartById(int id)
    {
       return _context.Carts.Find(id);
    }

    public void Remove(Cart cart)
    {
        _context.Carts.Remove(cart);
        _context.SaveChanges();
    }

    public void Update(Cart cart)
    {
        _context.Entry(cart).State = EntityState.Modified;
        _context.SaveChanges();
    }
}