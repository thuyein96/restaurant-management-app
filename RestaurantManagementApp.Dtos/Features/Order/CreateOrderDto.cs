namespace RestaurantManagementApp.Dtos.Features.Order;

public class CreateOrderDto
{
    public Guid? CustomerId { get; set;  }
    public Guid TableId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<CreateOrderDetailsDto> OrderItems { get; set; }
}