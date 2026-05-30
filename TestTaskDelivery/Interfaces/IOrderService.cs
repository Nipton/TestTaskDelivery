using TestTaskDelivery.DTOs;
using TestTaskDelivery.Models;

namespace TestTaskDelivery.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrdersAsync();
        Task<OrderResponse?> GetOrderResponseAsync(int id);
        Task<OrderRequest?> GetOrderRequestAsync(int id);
        Task<OrderResult> CreateOrderAsync(OrderRequest orderRequest);
        Task<OrderResult> UpdateOrderAsync(OrderRequest orderRequest);
        Task<City?> GetCityAsync(int id);
        Task<List<City>> GetCitiesAsync(string term);
    }
}
