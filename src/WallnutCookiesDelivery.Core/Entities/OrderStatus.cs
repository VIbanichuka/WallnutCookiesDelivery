using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WallnutCookiesDelivery.Core.Entities;

public class OrderStatus
{
    public int OrderStatusId { get; set; }

    [Required]
    [StringLength(20)]
    public string OrderStatusName { get; set; }
    public virtual  Order Order { get; set; }
}
