using RestaurantOrderingSystem.DTOs;

//TODO: THIS IS GENERIC IMPLEMENTATION

namespace RestaurantOrderingSystem.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerDTO customerDTO);
        Task UpdateCustomerAsync(int id, CustomerDTO customerDTO);
        Task DeleteCustomerAsync(int id);
    }
}
