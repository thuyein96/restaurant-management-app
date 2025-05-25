namespace RestaurantManagementApp.Dtos.Features.Cart;

public class CartDto
{
    public Guid CartId { get; set; }
    public Guid CustomerId { get; set; }
    public CustomerDto Customer { get; set; }
    public List<CartItemDto> CartItems { get; set; }

}