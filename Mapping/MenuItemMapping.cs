using ServiceSystem.Models;
using ServiceSystem.Models.Enum;
using ServiceSystem.Models.Request;

namespace ServiceSystem.Mapping
{
    public class MenuItemMapping
    {
        public MenuItem Map(CreateMenuItemRequest createMenuItemRequest)
        {
            return new MenuItem
            {
                Name = createMenuItemRequest.Name,
                Price = createMenuItemRequest.Price,
                OrderItemType = createMenuItemRequest.OrderItemType
            };
        }

        public void Map(UpdateMenuItemRequest updateMenuItemRequest, MenuItem menuItem)
        {
            if (updateMenuItemRequest.Name != null)
            {
                menuItem.Name = updateMenuItemRequest.Name;
            }

            if (updateMenuItemRequest.Price != default(decimal))
            {
                menuItem.Price = updateMenuItemRequest.Price;
            }

            if (updateMenuItemRequest.OrderItemType != 0)
            {
                menuItem.OrderItemType = updateMenuItemRequest.OrderItemType;
            }
        }
    }
}
