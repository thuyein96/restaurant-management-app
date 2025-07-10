namespace RestaurantManagementApp.Dtos.Features.Cart;

public class CreateCartDto
{
    public Guid CustomerId { get; set; }
    public int Total { get; set; }
    public List<CartItemDto>? CartItems { get; set; }
}