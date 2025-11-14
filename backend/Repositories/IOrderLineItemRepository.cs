using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.Repositories
{
    public interface IOrderLineItemRepository
    {
        Task AddOrderLineItemAsync(OrderLineItem orderLineItem);
    }
}
