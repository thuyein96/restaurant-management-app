namespace RestaurantManagementApp.Dtos.Features.User;

public class AdminDto
{
    public Guid AdminId { get; set; }
    public Guid UserId { get; set; }
    public UserDto User { get; set; }
    public string Password  { get; set; }
}