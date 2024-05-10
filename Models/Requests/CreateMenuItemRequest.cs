using ServiceSystem.Models.Enum;

namespace ServiceSystem.Models.Request
{
    public class CreateMenuItemRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public OrderItemType OrderItemType { get; set; }
    }
}
