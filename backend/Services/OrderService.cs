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

            return orders.Select(c => new OrderInfoDTO
            {
                OrderInfoId = c.OrderId,
                OrderStatus = c.OrderStatus,
                CreatedTime = c.CreatedTime,
                CompletedTime = c.CompletedTime,
                MenuItems = _menuItemRepository.GetAllMenuItemsByOrderId(c.OrderId).Select(m => new MenuItemDTO
                {
                    MenuItemId = m.MenuItemId,
                    MenuItemName = m.MenuItemName,
                    MenuItemDescription = m.MenuItemDescription,
                    MenuItemPrice = m.MenuItemPrice
                })
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
                MenuItems = _menuItemRepository.GetAllMenuItemsByOrderId(order.OrderId).Select(m => new MenuItemDTO
                {
                    MenuItemId = m.MenuItemId,
                    MenuItemName = m.MenuItemName,
                    MenuItemDescription = m.MenuItemDescription,
                    MenuItemPrice = m.MenuItemPrice
                })
            };
        }

        public async Task AddOrderAsync(OrderInfoDTO orderInfoDTO)
        {
            DateTime dt = DateTime.UtcNow;

            var order = new Order
            {
                OrderStatus = false,
                CreatedTime = dt,
                CompletedTime = null
            };

            await _orderRepository.AddOrderAsync(order);

            foreach(MenuItemDTO menuItem in orderInfoDTO.MenuItems)
            {
                var orderLineItem = new OrderLineItem
                {
                    OrderId = order.OrderId,
                    Order = order,
                    MenuItemId = menuItem.MenuItemId,
                    MenuItem = await _menuItemRepository.GetMenuItemByIdAsync(menuItem.MenuItemId)
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
