using WallnutCookiesDelivery.Web.Models;

namespace WallnutCookiesDelivery.Web.ViewModels;

public class MenuViewModel
{
    public MenuViewModel()
    {
        Products = new List<ProductModel>();
        Product = new ProductModel();
    }
    public List<ProductModel> Products { get; set; }
    public ProductModel Product { get; set; }
}
