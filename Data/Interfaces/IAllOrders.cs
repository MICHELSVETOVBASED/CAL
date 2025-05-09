using CalTechnology.Data.Models;
namespace CalTechnology.Data.Interfaces;

public interface IAllOrders
{
    void createOrder(Order order);
}