using AbbyRestaurant.DataAccess.Data;
using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;

namespace AbbyRestaurant.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MenuItem menuItem)
        {
            var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == menuItem.Id);
            objFromDb.Name = menuItem.Name;
            objFromDb.Description = menuItem.Description;
            objFromDb.Price = menuItem.Price;
            objFromDb.CategoryId = menuItem.CategoryId;
            objFromDb.FoodTypeId = menuItem.FoodTypeId;
            if(menuItem.Image != null)
            {
                objFromDb.Image = menuItem.Image;
            }

        }
    }
}
