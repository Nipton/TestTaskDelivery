using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskDelivery.DTOs;
using TestTaskDelivery.Interfaces;
using TestTaskDelivery.Models;

namespace TestTaskDelivery.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _orderService.GetAllOrdersAsync();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Upsert", new OrderRequest() { PickupDate = DateTime.Today});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderRequest orderRequest)
        {
            var order = await _orderService.CreateOrderAsync(orderRequest);
            TempData["Success"] = $"Заказ №{order.OrderNumber} создан";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderResponseAsync(id);
            return View(order);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var order = await _orderService.GetOrderRequestAsync(id);
            if (order == null)
                return NotFound();
            var senderCity = await _orderService.GetCityAsync(order.SenderCityId);
            var receiverCity = await _orderService.GetCityAsync(order.ReceiverCityId);
            ViewBag.SelectedSenderCity = senderCity?.Name ?? "";
            ViewBag.SelectedReceiverCity = receiverCity?.Name ?? "";
            return View("Upsert", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrderRequest orderRequest)
        {
            var result = await _orderService.UpdateOrderAsync(orderRequest);
            if (!result.Success)
                return NotFound();

            return RedirectToAction(nameof(Details),new { id = result.Id});
        }

        [HttpGet("/api/cities/search")]
        public async Task<IActionResult> SearchCities(string term)
        {
            var cities = await _orderService.GetCitiesAsync(term);
            return Json(cities.Select(c => new {c.Id, c.Name}));
        }
    }
}
