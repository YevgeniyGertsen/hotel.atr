using Hotel.Atr.BLL.Interfaces;
using Hotel.Atr.BLL.Model;
using Hotel.Atr.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAvailabilty, Availabilty>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IServiceRoom, ServiceRoom>();


builder.Services.AddSingleton<IRepository<Event>, Repository<Event>>();
builder.Services.AddSingleton<IRepository<EventCategory>, Repository<EventCategory>>();
builder.Services.AddSingleton<IRepository<Room>, Repository<Room>>();
builder.Services.AddSingleton<IRepository<RoomProperties>, Repository<RoomProperties>>();
builder.Services.AddSingleton<IRepository<Picture>, Repository<Picture>>();
builder.Services.AddSingleton<IRepository<Availabilty>, Repository<Availabilty>>();






builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultureList = new[]
    {
        new CultureInfo("ru"),
        new CultureInfo("kk"),
        new CultureInfo("en")
    };

    options.DefaultRequestCulture = new RequestCulture("ru-RU");
    options.SupportedCultures = cultureList;
    options.SupportedUICultures = cultureList;
});

builder.Services
    .AddLocalization(options => options.ResourcesPath = "Resources");

//глобавльный фильтр - все сервисы MVC и контроллеры и RazarPage
builder.Services.AddMvc(options => options
.Filters.Add(new IEFilterAttribute()));


builder.Services
    .AddControllersWithViews()
    .AddViewLocalization();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();



app.UseAuthorization();


//app.MapControllerRoute("ignoreRoute",
//    "{controller}/{action}/{id?}",
//    new { action = "^E.*" },
//    new { controller = "Index" });

//app.UseEndpoints(endpoints =>
//{

//});

//app.MapGet("/alias", async context =>
//{
//    await context.Response.WriteAsJsonAsync("<p>Hello Yevgeniy</p>");
//});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "WorkController/{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "",
//    pattern: "news2/{controller=Event}/{action=Index}/{id?}/{*cathall}");

//app.MapControllerRoute(
//    name: "MyRote",
//    pattern: "{phpMyAdmin}/{action}",
//    new { action = "Index", controller = "Event" });

//app.MapControllerRoute(
//    name: "MyRote",
//    pattern: "php/MyAdmin/{action}",
//    new { action = "Index", controller = "Event" });


//app.MapControllerRoute(
//    name: "",
//    pattern: "{controller}/{action}/{id}",
//    new { action = "Index", controller = "Event", id="Default" });

app.MapControllerRoute(
    name: "music",
    pattern: "WorkController/{controller=Home}/{action=Index}/{id?}");


//else
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseRouting();


var localizationOptions = app.Services
    .GetService<IOptions<RequestLocalizationOptions>>().Value;

app.UseRequestLocalization(localizationOptions);
     

//app.Use(async (context, next) =>
//{

//    await next(context);
//});



app.Run();
