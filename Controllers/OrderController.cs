using Microsoft.AspNetCore.Mvc;
using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;
using System.Diagnostics;

namespace CalTechnology.Controllers;

public class OrderController : Controller{
    private readonly IAllOrders allOrders;
    private readonly ShopCart shopCart;

    public OrderController(IAllOrders allOrders, ShopCart shopCart){
        this.allOrders = allOrders;
        this.shopCart = shopCart;
    }

    public IActionResult Checkout(){
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order){
        Debug.WriteLine("Starting checkout process");
        shopCart.listShopItems = shopCart.getShopItems();
        
        if (shopCart.listShopItems.Count == 0){
            Debug.WriteLine("Cart is empty");
            ModelState.AddModelError("", "You must have some items in cart");
            return View(order);
        }

        if (ModelState.IsValid){
            Debug.WriteLine("Model is valid, creating order");
            try {
                allOrders.createOrder(order);
                Debug.WriteLine("Order created successfully, redirecting to Complete");
                return RedirectToAction("Complete");
            }
            catch (Exception ex) {
                Debug.WriteLine($"Error creating order: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                ModelState.AddModelError("", $"Error creating order: {ex.Message}");
            }
        }
        else {
            Debug.WriteLine("Model is invalid");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors)) {
                Debug.WriteLine($"Validation error: {error.ErrorMessage}");
            }
        }

        return View(order);
    }

    public IActionResult Complete(){
        Debug.WriteLine("Complete action called");
        ViewBag.Message = "Order successfully processed";
        return View();
    }
}