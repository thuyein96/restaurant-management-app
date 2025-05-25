namespace RestaurantManagementApp.Dtos.Features.Cart;

public class UpdateCartDto
{
    public Guid CustomerId { get; set; }
    public CustomerDto Customer { get; set; }
    public List<CartItemDto>? CartItems { get; set; }
}