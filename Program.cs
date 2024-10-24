using WebCityEvents.Data;
using Microsoft.EntityFrameworkCore;
using WebCityEvents.Services;
using WebCityEvents;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSQLConnection")));

builder.Services.AddScoped<IOperationService, OperationService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMiddleware<DbInitializationMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();