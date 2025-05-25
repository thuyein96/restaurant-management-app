namespace RestaurantManagementApp.Dtos.Features.Cart;

public class UpdateCartItemDto
{
    public Guid CartId { get; set; }
    public Guid MenuItemId { get; set; }
    public CartDto Cart { get; set; }
    public MenuItemDto MenuItem { get; set; }
    public int Quantity { get; set; }
}