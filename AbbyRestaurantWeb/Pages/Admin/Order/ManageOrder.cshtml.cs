using AbbyRestaurant.DataAccess.Repository.IRepository;
using AbbyRestaurant.Models;
using AbbyRestaurant.Models.ViewModel;
using AbbyRestaurant.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyRestaurantWeb.Pages.Admin.Order
{
    [Authorize(Roles = $"{SD.ManagerRole},{SD.KitchenRole}")]
    public class ManageOrderModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<OrderDetailVM> OrderDetailVM { get; set; }
        public ManageOrderModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            OrderDetailVM = new();
            List<OrderHeader> orderHeaders = _unitOfWork.OrderHeader
                                                        .GetAll(u => u.Status == SD.StatusSubmitted || 
                                                                     u.Status == SD.StatusInProcess)
                                                        .ToList();
            foreach(OrderHeader header in orderHeaders)
            {
                OrderDetailVM individual = new OrderDetailVM()
                {
                    OrderHeader = header,
                    OrderDetails = _unitOfWork.OrderDetail.GetAll(u => u.OrderId == header.Id).ToList(),
                };
                OrderDetailVM.Add(individual);
            }
        }

        public IActionResult OnPostOrderInProcess(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusInProcess);
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }

        public IActionResult OnPostOrderReady(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusReady);
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }

        public IActionResult OnPostOrderCancel(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusCancelled);
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }
    }
}
