using Microsoft.AspNetCore.Mvc;
using CalTechnology.Data.Interfaces;
using CalTechnology.Data;
using Microsoft.EntityFrameworkCore;
using CalTechnology.Data.Repository;

using CalTechnology.Data.Models;

using Microsoft.Extensions.DependencyInjection;
using CalTechnology.Data.mocks;



    

var builder = WebApplication.CreateBuilder(args);



var hostEnv = builder.Environment;
IConfigurationRoot _confString = new ConfigurationBuilder()
    .SetBasePath(hostEnv.ContentRootPath)
    .AddJsonFile("dbsettings.json")
    .Build();
builder.Services.AddDbContext<AppDBContent>(options =>
    options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IAllCars,CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));

builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.Configure<MvcOptions>(options => {
    options.EnableEndpointRouting = false;
});



var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseCors();
//app.UseMvcWithDefaultRoute();//на главную страницу хоум индекс
 
using (var scope = app.Services.CreateScope()){
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}


/*app.MapControllerRoute(
    name: "Cars",
    pattern: "cars/{action=Index}/{id?}",
    defaults: new { controller = "Cars" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/


app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "{Car}/action/{category?}",
        defaults: new{ Controller = "Car", action = "List" });
});

if (app.Environment.IsDevelopment()){
    app.MapGet("/", () => "Development(production)");
}
else{
    app.MapGet("/", () => "Production");
}

app.Run();