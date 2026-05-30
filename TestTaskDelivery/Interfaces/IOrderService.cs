using TestTaskDelivery.DTOs;
using TestTaskDelivery.Models;

namespace TestTaskDelivery.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrdersAsync();
        Task<List<City>> GetCitiesAsync(string term);
    }
}
