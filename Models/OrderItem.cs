    using ServiceSystem.Models.Enum;

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
        public OrderItemType OrderItemType { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
