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

        public async Task<OrderResult> CreateOrderAsync(OrderRequest orderRequest)
        {
            ArgumentNullException.ThrowIfNull(orderRequest);
            Order order = new Order
            {
                OrderNumber = GenerateOrderNumber(),
                ReceiverCityId = orderRequest.ReceiverCityId,
                ReceiverAddress = orderRequest.ReceiverAddress,
                SenderCityId = orderRequest.SenderCityId,
                SenderAddress = orderRequest.SenderAddress,
                Weight = orderRequest.Weight,
                PickupDate = orderRequest.PickupDate,
            };
            _context.Add(order);
            await _context.SaveChangesAsync();
            var result = new OrderResult { Success = true, Id = order.Id, OrderNumber = order.OrderNumber };
            return result;
        }

        public async Task<OrderResult> UpdateOrderAsync(OrderRequest orderRequest)
        {
            ArgumentNullException.ThrowIfNull(orderRequest);
            var order = await _context.Orders.FindAsync(orderRequest.Id);
            if (order == null)
                return new OrderResult { Success = false, ErrorMessage = "Заказ не найден" };
            order.SenderCityId = orderRequest.SenderCityId;
            order.SenderAddress = orderRequest.SenderAddress;
            order.ReceiverCityId = orderRequest.ReceiverCityId;
            order.ReceiverAddress = orderRequest.ReceiverAddress;
            order.Weight = orderRequest.Weight;
            order.PickupDate = orderRequest.PickupDate;
            await _context.SaveChangesAsync();
            var result = new OrderResult { Success = true, Id = order.Id, OrderNumber = order.OrderNumber };
            return result;
        }

        private string GenerateOrderNumber()
        {
            var guid = Guid.NewGuid().ToString().Substring(0, 6);
            string number = $"ORD{guid}-{DateTime.Now:yyyyMMddHHmmss}";
            return number;
        }

        public async Task<OrderResponse?> GetOrderResponseAsync(int id)
        {
            var orderResponse = await _context.Orders
                .AsNoTracking()
                .Where(x => x.Id == id)
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
                .FirstOrDefaultAsync();
            return orderResponse;
        }

        public async Task<OrderRequest?> GetOrderRequestAsync(int id)
        {
            var orederRequest = await _context.Orders
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(o => new OrderRequest
                {
                    Id = o.Id,
                    ReceiverCityId = o.ReceiverCityId,
                    ReceiverAddress = o.ReceiverAddress,
                    SenderCityId = o.SenderCityId,
                    SenderAddress = o.SenderAddress,
                    Weight = o.Weight,
                    PickupDate = o.PickupDate
                })
                .FirstOrDefaultAsync();
            return orederRequest; 
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

        public async Task<City?> GetCityAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }
    }
}
