using CalTechnology.Data.Models;
using Microsoft.AspNetCore.Mvc;
using CalTechnology.ViewModels;
using CalTechnology.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CalTechnology.Controllers;

public class ShopCartController:Controller{
    private readonly IAllCars _carRep;
    private readonly ShopCart _shopCart;

    public ShopCartController(IAllCars carRep,ShopCart shopCart){
        _carRep = carRep;
        _shopCart = shopCart;
    }

    public ViewResult Index(){
        var items = _shopCart.getShopItems();
        _shopCart.listShopItems = items;

        var obj = new ShopCartViewModel{
            shopCart = _shopCart
        };
        return View(obj);
    }

    public RedirectToActionResult addToCart(int carId){
        var item = _carRep.Cars.FirstOrDefault(i => i.id == carId);
        if (item != null){
            _shopCart.AddToCart(item);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Complete(){
        ViewBag.Message = "Order succesfully processed";
        return View();
    }
}