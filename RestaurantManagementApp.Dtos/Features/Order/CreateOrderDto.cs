namespace RestaurantManagementApp.Dtos.Features.Order;

public class CreateOrderDto
{
    public Guid CustomerId { get; set;  }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<CreateOrderDetailsDto> OrderItems { get; set; }
}