namespace WallnutCookiesDelivery.Web.Models;

public class CartItemsModel
{
    public int CartItemId { get; set; }
    public ProductModel Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}