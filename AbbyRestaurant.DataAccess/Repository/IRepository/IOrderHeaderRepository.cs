using AbbyRestaurant.Models;

namespace AbbyRestaurant.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(int id, string status);
    }
}
