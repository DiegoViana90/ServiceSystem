using System;
using ServiceSystem.Models.Enum;

namespace ServiceSystem.Models.Request
{
    public class OrderRequest
    { 
        public int RestaurantTable { get; set; }
        public int MenuItem { get; set; }
        public OrderType OrderType { get; set; }
    }
}
