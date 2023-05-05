using AutoMapper;
using WallnutCookiesDelivery.Core.Entities;
using WallnutCookiesDelivery.Web.Models;

namespace WallnutCookiesDelivery.Web.AutoMapperConfig;

public class ApplicationProfile: Profile
{
    public ApplicationProfile()
    {
        CreateMap<Product, ProductModel>().ReverseMap();
        CreateMap<CartItem, CartItemsModel>().ReverseMap();
        CreateMap<Cart, CartModel>().ReverseMap();
    }
}
