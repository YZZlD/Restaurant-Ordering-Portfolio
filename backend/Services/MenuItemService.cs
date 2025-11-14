using RestaurantOrderingSystem.DTOs;
using RestaurantOrderingSystem.Models;
using RestaurantOrderingSystem.Repositories;

namespace RestaurantOrderingSystem.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _MenuItemRepository;

        public MenuItemService(IMenuItemRepository MenuItemRepository)
        {
            _MenuItemRepository = MenuItemRepository;
        }

        public async Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync()
        {
            var menuItems = await _MenuItemRepository.GetAllMenuItemsAsync();

            return menuItems.Select(c => new MenuItemDTO
            {
                MenuItemId = c.MenuItemId,
                MenuItemName = c.MenuItemName,
                MenuItemDescription = c.MenuItemDescription,
                MenuItemPrice = c.MenuItemPrice,
                ImageSource = c.ImageSource
            });
        }

        public async Task<MenuItemDTO> GetMenuItemByIdAsync(int id)
        {
            var menuItem = await _MenuItemRepository.GetMenuItemByIdAsync(id);

            return new MenuItemDTO
            {
                MenuItemId = menuItem.MenuItemId,
                MenuItemName = menuItem.MenuItemName,
                MenuItemDescription = menuItem.MenuItemDescription,
                MenuItemPrice = menuItem.MenuItemPrice,
                ImageSource = menuItem.ImageSource
            };
        }

        public async Task AddMenuItemAsync(MenuItemDTO menuItemDTO)
        {
            var menuItem = new MenuItem
            {
                MenuItemName = menuItemDTO.MenuItemName,
                MenuItemDescription = menuItemDTO.MenuItemDescription,
                MenuItemPrice = menuItemDTO.MenuItemPrice,
                ImageSource = menuItemDTO.ImageSource
            };

            await _MenuItemRepository.AddMenuItemAsync(menuItem);
        }

        public async Task UpdateMenuItemAsync(int id, MenuItemDTO menuItemDTO)
        {
            var menuItem = await _MenuItemRepository.GetMenuItemByIdAsync(id);

            if (menuItem == null) throw new KeyNotFoundException("MenuItem id not found.");

            menuItem.MenuItemName = menuItemDTO.MenuItemName;
            menuItem.MenuItemDescription = menuItemDTO.MenuItemDescription;
            menuItem.MenuItemPrice = menuItemDTO.MenuItemPrice;
            menuItem.ImageSource = menuItemDTO.ImageSource;

            await _MenuItemRepository.UpdateMenuItemAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItem = await _MenuItemRepository.GetMenuItemByIdAsync(id);

            if (menuItem == null) throw new KeyNotFoundException("MenuItem id not found.");

            await _MenuItemRepository.DeleteMenuItemAsync(id);
        }
    }
}
