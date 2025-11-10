using RestaurantOrderingSystem.DTOs;

//TODO: THIS IS GENERIC IMPLEMENTATION ALSO USER OF ORGANIZATION DTO CURRENTLY MIGHT CHANGE IN FUTURE

namespace RestaurantOrderingSystem.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrganizationOrderDTO>> GetAllOrdersAsync();
        Task<OrganizationOrderDTO> GetOrderByIdAsync(int id);
        Task AddOrderAsync(OrganizationOrderDTO organizationOrderDTO);
        Task UpdateOrderAsync(int id, OrganizationOrderDTO organizationOrderDTO);
        Task DeleteOrderAsync(int id);
    }
}
