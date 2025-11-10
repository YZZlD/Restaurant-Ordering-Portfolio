using RestaurantOrderingSystem.DTOs;

//TODO: THIS IS GENERIC IMPLEMENTATION ALSO USER OF ORGANIZATION DTO CURRENTLY MIGHT CHANGE IN FUTURE

namespace RestaurantOrderingSystem.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<ConsumerOrderDTO>> GetAllOrdersAsync();
        Task<ConsumerOrderDTO> GetOrderByIdAsync(int id);
        Task AddOrderAsync(ConsumerOrderDTO consumerOrderDTO);
        Task UpdateOrderAsync(int id, ConsumerOrderDTO consumerOrderDTO);
        Task DeleteOrderAsync(int id);
    }
}
