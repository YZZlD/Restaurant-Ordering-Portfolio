using RestaurantOrderingSystem.DTOs;

namespace RestaurantOrderingSystem.Services
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync();
        Task<MenuItemDTO> GetMenuItemByIdAsync(int id);
        Task AddMenuItemAsync(MenuItemDTO menuItemDto);
        Task UpdateMenuItemAsync(int id, MenuItemDTO menuItemDto);
        Task DeleteMenuItemAsync(int id);
    }
}
