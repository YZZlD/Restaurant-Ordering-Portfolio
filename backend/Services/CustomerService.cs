using RestaurantOrderingSystem.DTOs;
using RestaurantOrderingSystem.Models;
using RestaurantOrderingSystem.Repositories;

namespace RestaurantOrderingSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();

            return customers.Select(c => new CustomerDTO
            {
                Name = c.Name,
                EmailAddress = c.EmailAddress,
                PhoneNumber = c.PhoneNumber
            });
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            return new CustomerDTO
            {
                Name = customer.Name,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task AddCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                Name = customerDTO.Name,
                EmailAddress = customerDTO.EmailAddress,
                PhoneNumber = customerDTO.PhoneNumber
            };

            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerDTO customerDTO)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            if (customer == null) throw new KeyNotFoundException("Customer id not found.");

            customer.Name = customerDTO.Name;
            customer.EmailAddress = customerDTO.EmailAddress;
            customer.PhoneNumber = customerDTO.PhoneNumber;

            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);

            if (customer == null) throw new KeyNotFoundException("Customer id not found.");

            await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
