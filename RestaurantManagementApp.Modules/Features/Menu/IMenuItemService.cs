namespace RestaurantManagementApp.Modules.Features.Menu;

public interface IMenuItemService
{
    Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsAsync();
    Task<Result<MenuItemDto>> GetMenuItemByIdAsync(Guid menuItemId);
    Task<Result<MenuItemDto>> CreateMenuItemAsync(CreateMenuItemDto menuItemDto);
    Task<Result<MenuItemDto>> UpdateMenuItemAsync(Guid menuItemId, UpdateMenuItemDto menuItemDto);
    Task<Result<MenuItemDto>> DeleteMenuItemAsync(Guid menuItemId);
}