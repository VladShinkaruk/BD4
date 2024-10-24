using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebCityEvents.Data;

namespace WebCityEvents
{
    public class DbInitializationMiddleware
    {
        private readonly RequestDelegate _next;

        public DbInitializationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, EventContext dbContext)
        {
            DbInitializer.Initialize(dbContext);

            await _next(context);
        }
    }
}