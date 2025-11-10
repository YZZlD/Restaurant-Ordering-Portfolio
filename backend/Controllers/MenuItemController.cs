using RestaurantOrderingSystem.Services;
using RestaurantOrderingSystem.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystem.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItems = await _menuItemService.GetAllMenuItemsAsync();

            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);

            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuItemDTO menuItemDTO)
        {
            await _menuItemService.AddMenuItemAsync(menuItemDTO);

            return CreatedAtAction(nameof(GetById), new { id = menuItemDTO.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MenuItemDTO menuItemDTO)
        {
            await _menuItemService.UpdateMenuItemAsync(id, menuItemDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuItemService.DeleteMenuItemAsync(id);

            return NoContent();
        }
    }
}
