using AbbyRestaurant.DataAccess.Data;
using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;

namespace AbbyRestaurant.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.OrderHeader.Update(orderHeader);
        }

        public void UpdateStatus(int id, string status)
        {
            var orderFromDb = _db.OrderHeader.FirstOrDefault(u => u.Id == id);
            if(orderFromDb != null)
            {
                orderFromDb.Status = status;
            }
        }
    }
}
