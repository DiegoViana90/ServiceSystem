using System.Collections.Generic;
using ServiceSystem.Models.Enum;

namespace ServiceSystem.Models.Request
{
    public class CreateOrderRequest
    {
        public int RestaurantTableId { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
    }

    public class OrderItemRequest
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
