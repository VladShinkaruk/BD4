using Microsoft.AspNetCore.Mvc;
using WebCityEvents.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebCityEvents.Controllers
{
    public class TicketOrderController : Controller
    {
        private readonly EventContext _context;
        private const int PageSize = 20;

        public TicketOrderController(EventContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ResponseCache(Duration = 286, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult Index(string customerName, int page = 1)
        {
            var ticketOrders = _context.TicketOrders
                .Include(t => t.Customer)
                .Include(t => t.Event)
                .AsQueryable();

            if (!string.IsNullOrEmpty(customerName))
            {
                ticketOrders = ticketOrders
                    .Where(t => t.Customer.FullName.Contains(customerName));
            }

            var paginatedOrders = ticketOrders
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            return View(paginatedOrders);
        }
    }
}
