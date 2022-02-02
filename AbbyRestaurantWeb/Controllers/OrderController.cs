using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbbyRestaurantWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(string? status=null)
        {
            var orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties:"ApplicationUser");
            switch (status)
            {
                case "cancelled":
                    orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusCancelled || u.Status == SD.StatusRejected);
                    break;
                case "completed":
                    orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusCompleted);
                    break;
                case "ready":
                    orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusReady);
                    break;
                case "inprocess":
                    orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusInProcess || u.Status == SD.StatusSubmitted);
                    break;
 
            }
   
            return Json(new {data = orderHeaderList });
        }


    }
}
