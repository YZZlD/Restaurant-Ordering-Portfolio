using RestaurantOrderingSystem.DTOs;
using RestaurantOrderingSystem.Models;
using RestaurantOrderingSystem.Repositories;

//TODO: THIS IS GENERIC

namespace RestaurantOrderingSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IOrderLineItemRepository _orderLineItemRepository;

        public OrderService(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository, IOrderLineItemRepository orderLineItemRepository)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
            _orderLineItemRepository = orderLineItemRepository;
        }

        public async Task<IEnumerable<OrderInfoDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();

            return (IEnumerable<OrderInfoDTO>)orders.Select(async c => new OrderInfoDTO
            {
                OrderInfoId = c.OrderId,
                OrderStatus = c.OrderStatus,
                CreatedTime = c.CreatedTime,
                CompletedTime = c.CompletedTime,
                MenuItems = await _menuItemRepository.GetAllMenuItemsByOrderId(c.OrderId)
            });
        }

        public async Task<OrderInfoDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            return new OrderInfoDTO
            {
                OrderInfoId = order.OrderId,
                OrderStatus = order.OrderStatus,
                CreatedTime = order.CreatedTime,
                CompletedTime = order.CompletedTime,
                MenuItems = await _menuItemRepository.GetAllMenuItemsByOrderId(order.OrderId)
            };
        }

        public async Task AddOrderAsync(OrderInfoDTO orderInfoDTO)
        {
            var order = new Order
            {
                OrderStatus = orderInfoDTO.OrderStatus,
                CreatedTime = orderInfoDTO.CreatedTime,
                CompletedTime = orderInfoDTO.CompletedTime
            };

            await _orderRepository.AddOrderAsync(order);

            foreach(MenuItem menuItem in orderInfoDTO.MenuItems)
            {
                var orderLineItem = new OrderLineItem
                {
                    OrderId = order.OrderId,
                    Order = order,
                    MenuItemId = menuItem.MenuItemId,
                    MenuItem = menuItem
                };

                await _orderLineItemRepository.AddOrderLineItemAsync(orderLineItem);
            }


        }

        public async Task UpdateOrderAsync(int id, OrderInfoDTO orderInfoDTO)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null) throw new KeyNotFoundException("Order id not found.");

            order.OrderStatus = orderInfoDTO.OrderStatus;
            order.CreatedTime = orderInfoDTO.CreatedTime;
            order.CompletedTime = orderInfoDTO.CompletedTime;

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
