using ServiceSystem.Models;
using ServiceSystem.Models.Enum;
using ServiceSystem.Models.Request;
using System;

namespace ServiceSystem.Mapping
{
    public class OrderMapping
    {
        public Order Map(OrderRequest orderRequest)
        {
            return new Order
            {
                OrderType = orderRequest.OrderType,
                RestaurantTableId = orderRequest.RestaurantTable,
                MenuItemId = orderRequest.MenuItem,
                OpenOrder = true,
                TotalValue = 0, 
                CreationDate = DateTime.Now,
                ClosedDate = null
            };
        }
    }
}