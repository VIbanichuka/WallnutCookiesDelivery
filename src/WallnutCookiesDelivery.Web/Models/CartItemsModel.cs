namespace WallnutCookiesDelivery.Web.Models;

public class CartItemsModel
{
    public int Id { get; set; }
    public ProductModel Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}