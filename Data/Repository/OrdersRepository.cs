using CalTechnology.Data.Interfaces;
using CalTechnology.Data.Models;

namespace CalTechnology.Data.Repository;

public class OrdersRepository : IAllOrders
{
    private readonly AppDBContent appDBContent;
    private readonly ShopCart shopCart;

    public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart){
        this.appDBContent = appDBContent;
        this.shopCart = shopCart;
    }
    
    public void createOrder(Order order){
        order.orderTime = DateTime.Now;
        
        // Сначала сохраняем заказ, чтобы получить ID
        appDBContent.Order.Add(order);
        appDBContent.SaveChanges();

        var items = shopCart.listShopItems;

        foreach (var el in items){
            var orderDetail = new OrderDetail{
                CarID = el.carItem.id,
                orderID = order.Id,
                price = el.carItem.price
            };
            order.orderDetails.Add(orderDetail);
            appDBContent.OrderDetail.Add(orderDetail);
        }

        // Сохраняем детали заказа
        appDBContent.SaveChanges();
        shopCart.ClearCart();
    }
}