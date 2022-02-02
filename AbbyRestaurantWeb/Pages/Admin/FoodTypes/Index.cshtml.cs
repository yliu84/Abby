using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            FoodTypes = _unitOfWork.FoodType.GetAll();
        }
    }
}
