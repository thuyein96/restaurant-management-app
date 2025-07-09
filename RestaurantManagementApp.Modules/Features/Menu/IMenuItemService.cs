namespace RestaurantManagementApp.Modules.Features.Menu;

public interface IMenuItemService
{
    Task<Result<IEnumerable<MenuItemDto>>> GetMenuItemsAsync();
    Task<Result<MenuItemDto>> GetMenuItemByIdAsync(Guid menuItemId);
    Task<Result<MenuItemDto>> CreateMenuItemAsync(CreateMenuItemDto menuItemDto);
    Task<Result<MenuItemDto>> UpdateMenuItemAsync(Guid menuItemId, UpdateMenuItemDto menuItemDto);
    Task<Result<string>> AddMenuItemCategoryAsync(Guid menuitemid, Guid categoryId);
    Task<Result<string>> RemoveMenuItemCategoryAsync(Guid menuitemid);
    Task<Result<string>> AddCustomizeOptionsToMenuAsync(Guid menuitemid, Guid customizeOptionsIds);
    Task<Result<string>> RemoveCustomizeOptionsFromMenuAsync(Guid menuitemid, Guid customizeOptionsIds);
    Task<Result<MenuItemDto>> DeleteMenuItemAsync(Guid menuItemId);
}