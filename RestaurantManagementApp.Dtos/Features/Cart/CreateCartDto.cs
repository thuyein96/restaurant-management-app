namespace RestaurantManagementApp.Dtos.Features.Cart;

public class CreateCartDto
{
    public Guid CustomerId { get; set; }
    public CustomerDto CustomerDto { get; set; }
    public List<CartItemDto>? CartItems { get; set; }
}