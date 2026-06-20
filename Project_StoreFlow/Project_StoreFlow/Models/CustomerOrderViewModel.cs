using Project_StoreFlow.Entities;

namespace Project_StoreFlow.Models
{
    public class CustomerOrderViewModel
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
