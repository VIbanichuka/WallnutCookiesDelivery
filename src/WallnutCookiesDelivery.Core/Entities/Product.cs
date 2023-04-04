using System.ComponentModel.DataAnnotations;
namespace WallnutCookiesDelivery.Core.Entities;

public class Product
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string Description { get; set; }
    
    [MaxLength(200)]
    public string ImageUrl { get; set; }
}
