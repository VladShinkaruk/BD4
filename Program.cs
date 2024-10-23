using WebCityEvents.Data;
using Microsoft.EntityFrameworkCore;
using WebCityEvents.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавление DbContext
builder.Services.AddDbContext<EventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSQLConnection")));
builder.Services.AddScoped<IOperationService, OperationService>();

// Добавление MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
