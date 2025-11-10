using RestaurantOrderingSystem.Services;
using RestaurantOrderingSystem.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrganizationOrderDTO organizationOrderDTO)
        {
            await _orderService.AddOrderAsync(organizationOrderDTO);

            return CreatedAtAction(nameof(GetById), new { id = organizationOrderDTO.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrganizationOrderDTO organizationOrderDTO)
        {
            await _orderService.UpdateOrderAsync(id, organizationOrderDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orderService.DeleteOrderAsync(id);
                return NoContent();
            } catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
