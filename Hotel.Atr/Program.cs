using Hotel.Atr.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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


app.MapControllerRoute(
    name: "default",
    pattern: "WorkController/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "",
    pattern: "news/{controller=Event}/{action=Index}/{id?}/{*cathall}");

app.MapControllerRoute(
    name: "MyRote",
    pattern: "{phpMyAdmin}/{action}",
    new { action = "Index", controller = "Event" });

app.MapControllerRoute(
    name: "MyRote",
    pattern: "php/MyAdmin/{action}",
    new { action = "Index", controller = "Event" });


app.MapControllerRoute(
    name: "",
    pattern: "{controller}/{action}/{id}",
    new { action = "Index", controller = "Event", id="Default" });



//else
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseRouting();



app.UserReqestCulture();

//app.Use(async (context, next) =>
//{

//    await next(context);
//});



app.Run();
