using AbbyRestaurant.DataAccess.Data;
using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbbyRestaurantWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpSertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpSertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            MenuItem = new();
        }

        public void OnGet(int? id)
        {
            if(id != null)
            {
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(x => x.Id == id);
            }
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(MenuItem.Id == 0)
            {
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using(var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.Image = @"\images\menuItems\" + fileName_new + extension;

                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.Save();
            }
            else
            {
                var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == MenuItem.Id);
                if(files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\menuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    // delete the old image
                    var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    // upload new image
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    MenuItem.Image = @"\images\menuItems\" + fileName_new + extension;
                }
                else
                {
                    MenuItem.Image = objFromDb.Image;
                }
                _unitOfWork.MenuItem.Update(MenuItem);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");

        }
    }
}
