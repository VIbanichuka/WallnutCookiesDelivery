using System.ComponentModel.DataAnnotations;
namespace WallnutCookiesDelivery.Web.Models;

public class Customer
{

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "First Name:")]
    public string FirstName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Last Name:")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Phone Number:")]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Street Number:")]
    public int StreetNumber { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Street Name:")]
    public string? StreetName { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "City:")]
    public string? City { get; set; }

    [Display(Name = "Delivery Instructions:")]
    public string DeliveryInstruction { get; set; }
}
