using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskDelivery.Interfaces;
using TestTaskDelivery.Models;
using TestTaskDelivery.DTOs;

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
            return View("Upsert", new OrderRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderRequest orderRequest)
        {
            TempData["Success"] = "Заказ №123 создан";
            return RedirectToAction(nameof(Index));
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
    }
}
