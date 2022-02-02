using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Admin.Order
{
    [Authorize]
    public class OrderListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
