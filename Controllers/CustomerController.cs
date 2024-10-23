using Microsoft.AspNetCore.Mvc;
using WebCityEvents.Data;
using WebCityEvents.Models;
using System.Linq;

namespace WebCityEvents.Controllers
{
    public class CustomerController : Controller
    {
        private readonly EventContext _context;
        private const int PageSize = 20;

        public CustomerController(EventContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ResponseCache(Duration = 286, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult Index(int page = 1)
        {
            var totalCustomers = _context.Customers.Count();
            var totalPages = (int)System.Math.Ceiling(totalCustomers / (double)PageSize);

            var customers = _context.Customers
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(customers);
        }
    }
}
