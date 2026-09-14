using lesson_3_1_3.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("ru-RU");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});







app.Run();
