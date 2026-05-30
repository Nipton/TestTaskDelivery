using Microsoft.EntityFrameworkCore;
using TestTaskDelivery.Data;
using TestTaskDelivery.DTOs;
using TestTaskDelivery.Interfaces;
using TestTaskDelivery.Models;

namespace TestTaskDelivery.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationContext _context;
        public OrderService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<OrderResponse>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .AsNoTracking()
                .OrderByDescending(o => o.Id)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    SenderCityName = o.SenderCity.Name,
                    SenderAddress = o.SenderAddress,
                    ReceiverCityName = o.ReceiverCity.Name,
                    ReceiverAddress = o.ReceiverAddress,
                    Weight = o.Weight,
                    PickupDate = o.PickupDate,
                })
                .ToListAsync();
        }

        public async Task<CreateOrderResult> CreateOrderAsync(OrderRequest orderRequest)
        {
            ArgumentNullException.ThrowIfNull(orderRequest);
            Order order = new Order
            {
                OrderNumber = GenerateOrderNumber(),
                ReceiverCityId = orderRequest.ReceiverCityId,
                ReceiverAddress = orderRequest.ReceiverAddress,
                SenderCityId = orderRequest.SenderCityId,
                SenderAddress = orderRequest.SenderAddress,
                Weight = orderRequest.Weight ?? 0,
                PickupDate = orderRequest.PickupDate,
            };

        }

        private string GenerateOrderNumber()
        {
            string number = string.Empty;
            return number;

        }

        public async Task<List<City>> GetCitiesAsync(string term)
        {
            if(string.IsNullOrWhiteSpace(term) || term.Length < 2)
                return new List<City>();
            var searchTerm = term.ToUpper();
            var cities = await _context.Cities
                .AsNoTracking()
                .Where(c => c.NameNormalized
                .Contains(searchTerm))
                .Take(7)
                .ToListAsync();
            return cities;
        }
    }
}
