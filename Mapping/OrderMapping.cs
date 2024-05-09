using ServiceSystem.Models;
using ServiceSystem.Models.Enum;
using ServiceSystem.Models.Request;
using System;
using System.Linq;

namespace ServiceSystem.Mapping
{
    public class OrderMapping
    {
        public Order Map(CreateOrderRequest createOrderRequest, Order existingOrder = null)
        {
            OrderItemType orderItemType = createOrderRequest.OrderItems.Any(item => item.MenuItemId == 1 || item.MenuItemId == 2) ? OrderItemType.Food :
                                   OrderItemType.Drink;

            if (existingOrder == null)
            {
                return new Order
                {
                    RestaurantTableId = createOrderRequest.RestaurantTableId,
                    OrderItemType = orderItemType,
                    OrderStatus = true,
                    TotalValue = 0,
                    CreationDate = DateTime.Now,
                    ClosedDate = null
                };
            }
            else
            {
                existingOrder.RestaurantTableId = createOrderRequest.RestaurantTableId;
                existingOrder.OrderItemType = orderItemType;
                existingOrder.OrderStatus = true;
                existingOrder.CreationDate = DateTime.Now;
                existingOrder.ClosedDate = null;
                return existingOrder;
            }
        }
    }
}
