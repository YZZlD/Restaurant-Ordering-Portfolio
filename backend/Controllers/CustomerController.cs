using RestaurantOrderingSystem.Services;
using RestaurantOrderingSystem.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerDTO customerDTO)
        {
            await _customerService.AddCustomerAsync(customerDTO);

            return CreatedAtAction(nameof(GetById), new { id = customerDTO.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerDTO customerDTO)
        {
            await _customerService.UpdateCustomerAsync(id, customerDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}
