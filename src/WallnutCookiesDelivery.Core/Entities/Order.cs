using System;
namespace WallnutCookiesDelivery.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public string Status { get; set; }
    public DateTime DateOrdered { get; set; }
    public decimal TotalPrice { get; set; }
}
