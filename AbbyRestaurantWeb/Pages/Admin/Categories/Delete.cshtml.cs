using AbbyRestaurant.DataAccess.Data;
using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {

            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id == Category.Id);
            if (categoryFromDb != null)
            {
                _unitOfWork.Category.Remove(categoryFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";

                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
