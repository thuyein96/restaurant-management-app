namespace RestaurantManagementApp.Dtos.Features.MenuItemCustomizeOption;

public class CreateMenuItemCustomizeOptionDto
{
    public Guid MenuItemId { get; set; }
    public Guid CustomizeOptionId { get; set; }
    public CustomizeOptionDto CustomizeOption { get; set; }
    public MenuItemDto MenuItem { get; set; }
}