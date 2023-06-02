using System.ComponentModel.DataAnnotations;
namespace WallnutCookiesDelivery.Web.Models;

public class ProductModel
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Please enter product name")]
    [Display(Name = "Product Name:")]
    public string Name { get; set; }

    public string ImageUrl { get; set; }

    [Required(ErrorMessage = "The value is required")]
    [Display(Name = "Price:")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "This is required")]
    [Display(Name = "Description:")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Upload an image")]
    [Display(Name = "Product Image:")]
    public IFormFile ImageFile { get; set; }
}