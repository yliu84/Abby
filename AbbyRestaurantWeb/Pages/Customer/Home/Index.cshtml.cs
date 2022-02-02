using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel (IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public IEnumerable<MenuItem> MenuItemList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public void OnGet()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            CategoryList = _unitOfWork.Category.GetAll(orderBy: u => u.OrderBy(c => c.DisplayOrder));
        }
    }
}
