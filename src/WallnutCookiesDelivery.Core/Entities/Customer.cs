using System.ComponentModel.DataAnnotations;

namespace WallnutCookiesDelivery.Core.Entities;

public class Customer
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(20)]
    public string LastName { get; set; }
    public string Email { get; set; }
    [MaxLength(15)]
    public string PhoneNumber { get; set; }
    public int StreetNumber { get; set; }
    [MaxLength(100)]
    public string StreetName { get; set; }
    [MaxLength(30)]
    public string City { get; set; }
    [MaxLength(100)]
    public string Country { get; set; }
}
