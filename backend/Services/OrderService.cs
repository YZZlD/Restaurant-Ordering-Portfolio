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

        public async Task<IEnumerable<OrganizationOrderDTO>> GetAllOrdersAsync()
        {
            var Orders = await _orderRepository.GetAllOrdersAsync();

            return Orders.Select(c => new OrganizationOrderDTO
            {
                OrderStatus = c.OrderStatus,
                CreatedTime = c.CreatedTime,
                CompletedTime = c.CompletedTime,
                MenuItem = c.MenuItem
            });
        }

        public async Task<OrganizationOrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            return new OrganizationOrderDTO
            {
                OrderStatus = order.OrderStatus,
                CreatedTime = order.CreatedTime,
                CompletedTime = order.CompletedTime,
                MenuItem = order.MenuItem
            };
        }

        public async Task AddOrderAsync(OrganizationOrderDTO organizationOrderDTO)
        {
            var order = new Order
            {
                OrderStatus = organizationOrderDTO.OrderStatus,
                CreatedTime = organizationOrderDTO.CreatedTime,
                CompletedTime = organizationOrderDTO.CompletedTime,
                MenuItem = organizationOrderDTO.MenuItem
            };

            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int id, OrganizationOrderDTO organizationOrderDTO)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null) throw new KeyNotFoundException("Order id not found.");

            order.OrderStatus = organizationOrderDTO.OrderStatus;
            order.CreatedTime = organizationOrderDTO.CreatedTime;
            order.CompletedTime = organizationOrderDTO.CompletedTime;
            order.MenuItem = organizationOrderDTO.MenuItem;

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
