using System.ComponentModel.DataAnnotations;

namespace WallnutCookiesDelivery.Core.Entities;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    public string UserName { get; set; }

    [MaxLength(20)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(20)]
    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [MaxLength(15)]
    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public int StreetNumber { get; set; }

    [MaxLength(100)]
    [Required]
    public string StreetName { get; set; }

    [MaxLength(30)]
    [Required]
    public string City { get; set; }

    [MaxLength(100)]
    [Required]
    public string Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
    
    public Customer()
    {
        Orders = new HashSet<Order>();
    }
}
