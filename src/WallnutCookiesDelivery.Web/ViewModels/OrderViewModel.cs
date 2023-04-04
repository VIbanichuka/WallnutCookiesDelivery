using Microsoft.AspNetCore.Mvc.Rendering;
using WallnutCookiesDelivery.Web.Models;

namespace WallnutCookiesDelivery.Web.ViewModels;

public class OrderViewModel
{
    public AddressType AddressType { get; set; }
    public Customer Customer { get; set; }
    public string SelectedCountry { get; set; }
    public List<SelectListItem> CountriesSelectList { get; set; }
}
