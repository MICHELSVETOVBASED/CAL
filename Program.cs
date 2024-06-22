using Microsoft.AspNetCore.Mvc;
using CalTechnology.Data.Interfaces;
using CalTechnology.Data;
using Microsoft.EntityFrameworkCore;
using CalTechnology.Data.Repository;
using System.ComponentModel;
using CalTechnology.Data.Models;

/*using Microsoft.Extensions.DependencyInjection;
using CalTechnology.Data.mocks;*/



    

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
app.UseMvcWithDefaultRoute();

using (var scope = app.Services.CreateScope()){
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}






app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Cars",
        pattern: "cars/{action=Index}/{id?}",
        defaults: new { controller = "Cars" });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


        


if (app.Environment.IsDevelopment()){
    app.MapGet("/", () => "Development(production)");
}
else{
    app.MapGet("/", () => "Production");
}

app.Run();