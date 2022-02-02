using AbbyRestaurant.DataAccess.Data;
using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Admin.FoodTypes
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public FoodType FoodType { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id==id);
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.FoodType.Update(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }

            return Page();
           
        }
    }
}
