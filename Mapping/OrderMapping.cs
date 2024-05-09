using ServiceSystem.Models;
using ServiceSystem.Models.Enum;
using ServiceSystem.Models.Request;
using System;
using System.Linq;

namespace ServiceSystem.Mapping
{
    public class OrderMapping
    {
        public Order Map(CreateOrderRequest createOrderRequest)
        {
            OrderItemType OrderItemType = createOrderRequest.OrderItems.Any(item => item.MenuItemId == 1 || item.MenuItemId == 2) ? OrderItemType.Food :
                                   OrderItemType.Drink;

            return new Order
            {
                RestaurantTableId = createOrderRequest.RestaurantTableId,
                OrderItemType = OrderItemType,
                OrderStatus = true,
                TotalValue = 0, 
                CreationDate = DateTime.Now, 
                ClosedDate = null 
            };
        }
    }
}
