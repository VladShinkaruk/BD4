using Microsoft.AspNetCore.Mvc;
using WebCityEvents.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebCityEvents.Controllers
{
    public class EventController : Controller
    {
        private readonly EventContext _context;
        private const int PageSize = 20;

        public EventController(EventContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ResponseCache(Duration = 286, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult Index(int page = 1)
        {
            var events = _context.Events
                .Include(e => e.Organizer)
                .Where(e => e.Organizer != null)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            return View(events);
        }
    }
}