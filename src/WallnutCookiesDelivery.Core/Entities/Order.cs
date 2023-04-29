using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WallnutCookiesDelivery.Core.Entities;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public int OrderStatusId { get; set; }
    [MaxLength(20)]
    public int CustomerId {get; set;}
    public DateTime DateOrdered { get; set; } = DateTime.UtcNow;
    
    [Column(TypeName = "money")]
    [Required]
    public decimal TotalPrice { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual OrderStatus OrderStatus { get; set; }    
}