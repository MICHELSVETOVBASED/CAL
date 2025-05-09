using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CalTechnology.Data.Models;
namespace CalTechnology.Data.Models;

public class ShopCart{
    private readonly AppDBContent appDBContent;
    public ShopCart(AppDBContent appDBContent){
        this.appDBContent = appDBContent;
    }
    public string ShopCartId{ get; set; }
    public List<ShopCartItem> listShopItems{ get; set; }

    public static ShopCart GetCart(IServiceProvider services){
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<AppDBContent>();
        string ShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", ShopCartId);
        return new ShopCart(context){
            ShopCartId = ShopCartId
        };
    }

    public void AddToCart(Car car){
        appDBContent.ShopCartItem.Add(new ShopCartItem{
            ShopCartId = ShopCartId,
            carItem = car,
            price = car.price
        });
        appDBContent.SaveChanges();
    }

    public List<ShopCartItem> getShopItems(){
        return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId)
            .Include(s => s.carItem)
            .ToList();
    }
}