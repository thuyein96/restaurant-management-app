namespace RestaurantManagementApp.Dtos.Features.MenuItemCustomizeOption;

public class MenuItemCustomizeOptionDto
{
    public Guid MenuItemCustomizeOptionId { get; set; }
    public Guid MenuItemId { get; set; }
    public Guid CustomizeOptionId { get; set; }
    public MenuItemDto MenuItem { get; set; }
    public CustomizeOptionDto CustomizeOption { get; set; }
}