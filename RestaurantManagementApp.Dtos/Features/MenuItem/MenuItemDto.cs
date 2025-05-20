namespace RestaurantManagementApp.Dtos.Features.MenuItem;

public class MenuItemDto
{
    public Guid MenuItemId { get; set; }
    public string MenuItemName { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}