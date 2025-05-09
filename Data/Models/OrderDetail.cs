namespace CalTechnology.Data.Models;

public class OrderDetail
{
    public int Id { get; set; }

    public int orderID { get; set; }

    public int CarID { get; set; }

    public uint price { get; set; }

    public virtual Car car { get; set; }

    public virtual Order order { get; set; }
    
}