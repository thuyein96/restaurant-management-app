namespace RestaurantManagementApp.Dtos.Features.Order;

public class CreateOrderDetailsDto
{
    public Guid OrderId { get; set; }
    public Guid MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal { get; set; }
}