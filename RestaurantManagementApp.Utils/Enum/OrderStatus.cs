namespace RestaurantManagementApp.Utils.Enum;

public class OrderStatus : SmartEnum<OrderStatus>
{
    public static readonly OrderStatus Pending = new OrderStatus("Pending", 1);
    public static readonly OrderStatus Confirmed = new OrderStatus("Confirmed", 2);
    public static readonly OrderStatus Paid = new OrderStatus("Paid", 3);
    public OrderStatus(string name, int value) : base(name, value)
    {
    }
}