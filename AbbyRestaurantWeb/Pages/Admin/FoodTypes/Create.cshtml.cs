using AbbyRestaurant.DataAccess.Data;
using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public FoodType FoodType { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodType.Add(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType created successfully";
                return RedirectToPage("Index");
            }

            return Page();
           
        }
    }
}
