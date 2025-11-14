using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;

//TODO: THIS IS A GENERIC IMPLEMENTATION OF ACCESSING THE CUSTOMER TABLE FROM THE DATABASE THIS WILL CHANGE LATER FOR MORE SPECIFIC QUERIES THIS MIGHT ALSO BE MERGED WITH THE ORDERING
//REPOSITORY AS WE MIGHT NOT ACCESS CUSTOMER INFORMATION SEPERATELY

namespace RestaurantOrderingSystem.Repositories
{
    public class CustomersRepository : ICustomerRepository
    {
        private readonly RestaurantDbContext _context;

        public CustomersRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddCustomerAsync(Customer Customer)
        {
            await _context.Customers.AddAsync(Customer);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer Customer)
        {
            _context.Customers.Update(Customer);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            Customer Customers = await _context.Customers.FindAsync(id);

            if (Customers != null)
            {
                _context.Customers.Remove(Customers);

                await _context.SaveChangesAsync();
            }

        }
    }
}
