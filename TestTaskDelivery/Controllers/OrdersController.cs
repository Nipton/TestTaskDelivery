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
        public IActionResult Create()
        {
            return View("Upsert", new OrderRequest() { PickupDate = DateTime.Today});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
            {
                await SetSelectedCitiesNames(orderRequest);
                return View("Upsert", orderRequest);
            }
            var result = await _orderService.CreateOrderAsync(orderRequest);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage!);
                await SetSelectedCitiesNames(orderRequest);
                return View("Upsert", orderRequest);
            }
            TempData["Success"] = $"Заказ №{result.OrderNumber} создан.";
            return RedirectToAction(nameof(Index));
        }
       
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderResponseAsync(id);
            if (order == null)
                return NotFound();
            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
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
        public async Task<IActionResult> Edit(OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
            {
                await SetSelectedCitiesNames(orderRequest);
                return View("Upsert", orderRequest);
            }
            var result = await _orderService.UpdateOrderAsync(orderRequest);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage!);
                await SetSelectedCitiesNames(orderRequest);
                return View("Upsert", orderRequest);
            }
            TempData["Success"] = $"Заказ №{result.OrderNumber} обновлён.";
            return RedirectToAction(nameof(Details),new { id = result.Id});
        }

        [HttpGet("/api/cities/search")]
        public async Task<IActionResult> SearchCities(string term)
        {
            var cities = await _orderService.GetCitiesAsync(term);
            return Json(cities.Select(c => new {c.Id, c.Name}));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task SetSelectedCitiesNames(OrderRequest orderRequest)
        {
            if (orderRequest.SenderCityId != 0)
            {
                var senderCity = await _orderService.GetCityAsync(orderRequest.SenderCityId);
                ViewBag.SelectedSenderCity = senderCity?.Name ?? "";
            }

            if (orderRequest.ReceiverCityId != 0)
            {
                var receiverCity = await _orderService.GetCityAsync(orderRequest.ReceiverCityId);
                ViewBag.SelectedReceiverCity = receiverCity?.Name ?? "";
            }
        }
    }
}
