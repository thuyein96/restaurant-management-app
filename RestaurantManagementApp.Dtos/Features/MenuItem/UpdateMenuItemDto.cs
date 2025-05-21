namespace RestaurantManagementApp.Dtos.Features.MenuItem;

public class UpdateMenuItemDto
{
    public string MenuItemName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryDto Category { get; set; }
    public ICollection<MenuItemCustomizeOptionDto> MenuItemCustomizeOptions { get; set; }
}