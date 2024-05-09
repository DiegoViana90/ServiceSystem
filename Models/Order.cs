using System;
using ServiceSystem.Models.Enum;

namespace ServiceSystem.Models
{
    public class Order
    { 
        public int Id { get; set; }
        public OrderType OrderType { get; set; }
        public int RestaurantTableId { get; set; }
        public RestaurantTable RestaurantTable { get; set; }
        public bool OpenOrder { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
