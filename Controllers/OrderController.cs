using Microsoft.AspNetCore.Mvc;
using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;
namespace CalTechnology.Controllers;

public class OrderController : Controller{
    private readonly IAllOrders allOrders;//до репозитория одно и то же что и OrdersRepository
    private readonly ShopCart shopCart;

    public OrderController(IAllOrders allOrders, ShopCart shopCart){
        this.allOrders = allOrders;
        this.shopCart = shopCart;
    }

    public IActionResult Checkout(){
        return View();//функции возвращают HTML шаблон
    }
}