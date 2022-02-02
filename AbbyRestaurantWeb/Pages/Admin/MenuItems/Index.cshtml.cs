using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<MenuItem>? MenuItems { get; set; }
        public void OnGet()
        {
            //MenuItems = _unitOfWork.MenuItem.GetAll();
        }
    }
}
