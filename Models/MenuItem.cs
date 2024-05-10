using ServiceSystem.Models.Enum;

public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public OrderItemType OrderItemType { get; set; }
    }