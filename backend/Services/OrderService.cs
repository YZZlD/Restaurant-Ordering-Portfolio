using RestaurantOrderingSystem.DTOs;
using RestaurantOrderingSystem.Models;
using RestaurantOrderingSystem.Repositories;

//TODO: THIS IS GENERIC

namespace RestaurantOrderingSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<ConsumerOrderDTO>> GetAllOrdersAsync()
        {
            var Orders = await _orderRepository.GetAllOrdersAsync();

            return Orders.Select(c => new ConsumerOrderDTO
            {
                OrderStatus = c.OrderStatus,
                CreatedTime = c.CreatedTime,
                CompletedTime = c.CompletedTime,
                MenuItem = c.MenuItem
            });
        }

        public async Task<ConsumerOrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            return new ConsumerOrderDTO
            {
                OrderStatus = order.OrderStatus,
                CreatedTime = order.CreatedTime,
                CompletedTime = order.CompletedTime,
                MenuItem = order.MenuItem
            };
        }

        public async Task AddOrderAsync(ConsumerOrderDTO orderDTO)
        {
            var order = new Order
            {
                OrderStatus = orderDTO.OrderStatus,
                CreatedTime = orderDTO.CreatedTime,
                CompletedTime = orderDTO.CompletedTime,
                MenuItem = orderDTO.MenuItem
            };

            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int id, ConsumerOrderDTO consumerOrderDTO)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null) throw new KeyNotFoundException("Order id not found.");

            order.OrderStatus = consumerOrderDTO.OrderStatus;
            order.CreatedTime = consumerOrderDTO.CreatedTime;
            order.CompletedTime = consumerOrderDTO.CompletedTime;
            order.MenuItem = consumerOrderDTO.MenuItem;

            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null) throw new KeyNotFoundException("Order id not found.");

            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}
