namespace RestaurantManagementApp.Dtos.Features.Cart;

public class CreateCartItemDto
{
    public Guid CartId { get; set; }
    public Guid MenuItemId  { get; set; }
    public int Quantity { get; set; }
}