using Microsoft.AspNetCore.Mvc;
using CalTechnology.Data.Interfaces;
using CalTechnology.Data.mocks;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<IAllCars,MockCars>();
builder.Services.AddTransient<ICarsCategory, MockCategory>();
builder.Services.AddMvc();
builder.Services.Configure<MvcOptions>(options => {
    options.EnableEndpointRouting = false;
});



var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseMvcWithDefaultRoute();





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
    app.MapGet("/", () => "Production");
    app.Run();
}

app.MapGet("/", () => "Hello World!");

app.Run();