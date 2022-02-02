using AbbyRestaurant.Models;

namespace AbbyRestaurant.DataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetails>
    {
        void Update(OrderDetails orderDetails);
    }
}
