namespace RestaurantManagementApp.Dtos.Features.Order;

public class OrderDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderDetailsDto> OrderDetails { get; set; }
}