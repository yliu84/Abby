using AbbyRestaurant.Models;

namespace AbbyRestaurant.DataAccess.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem menuItem);
    }
}
