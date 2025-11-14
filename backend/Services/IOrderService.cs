using RestaurantOrderingSystem.DTOs;

namespace RestaurantOrderingSystem.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderInfoDTO>> GetAllOrdersAsync();
        Task<OrderInfoDTO> GetOrderByIdAsync(int id);
        Task AddOrderAsync(OrderInfoDTO orderDTO);
        Task UpdateOrderAsync(int id, OrderInfoDTO orderDTO);
        Task DeleteOrderAsync(int id);
    }
}
