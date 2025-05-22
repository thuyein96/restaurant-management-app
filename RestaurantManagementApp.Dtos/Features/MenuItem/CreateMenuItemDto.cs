namespace RestaurantManagementApp.Dtos.Features.MenuItem;

public class CreateMenuItemDto
{
    public string MenuItemName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public ICollection<CustomizeOptionDto> CustomizeOptions { get; set; }
}