namespace RestaurantManagementApp.Dtos.Features.User;

public class CustomerDto
{
    public Guid CustomerId { get; set; }
    public Guid UserId { get; set; }
    public UserDto User { get; set; }
}