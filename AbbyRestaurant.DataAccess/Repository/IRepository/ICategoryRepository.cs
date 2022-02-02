using AbbyRestaurant.Models;

namespace AbbyRestaurant.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
