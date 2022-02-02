namespace AbbyRestaurant.Models.ViewModel
{
    public class OrderDetailVM
    { 
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
