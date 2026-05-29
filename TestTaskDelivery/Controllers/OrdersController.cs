using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskDelivery.Models;

namespace TestTaskDelivery.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
