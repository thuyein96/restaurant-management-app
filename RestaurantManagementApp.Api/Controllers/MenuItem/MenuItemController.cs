namespace RestaurantManagementApp.Api.Controllers.MenuItem;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController : BaseController
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [SwaggerOperation(Summary = "Get all existing menu items")]
    [HttpGet]
    public async Task<IActionResult> GetMenuItems()
    {
        var result = await _menuItemService.GetMenuItemsAsync();
        return Content(result);
    }

    [SwaggerOperation(Summary = "Get an menu item by id")]
    [HttpGet("{menuitemid}")]
    public async Task<IActionResult> GetMenuItemById(Guid menuitemid)
    {
        var result = await _menuItemService.GetMenuItemByIdAsync(menuitemid);
        return Content(result);
    }

    [SwaggerOperation(Summary = "Create an menu item")]
    [HttpPost]
    public async Task<IActionResult> CreateMenuItem(
        [FromBody] CreateMenuItemDto menuItemDto
    )
    {
        var result = await _menuItemService.CreateMenuItemAsync(menuItemDto);
        return Content(result);
    }

    [SwaggerOperation( Summary = "Update an existing menu item" )]
    [HttpPut("{menuitemid}")]
    public async Task<IActionResult> UpdateMenuItem(
        Guid menuitemid,
        [FromBody] UpdateMenuItemDto menuItemDto
    )
    {
        var result = await _menuItemService.UpdateMenuItemAsync(menuitemid, menuItemDto);
        return Content(result);
    }

    [SwaggerOperation(Summary = "Add menu item to category")]
    [HttpPatch("{categoryId}/category/{menuitemid}")]
    public async Task<IActionResult> AddMenuItemToCategory(Guid menuitemid, Guid categoryId)
    {
        var result = await _menuItemService.AddMenuItemCategoryAsync( menuitemid, categoryId);
        return Content(result);
    }

    [SwaggerOperation(Summary = "Remove menu item from category")]
    [HttpDelete("{menuitemid}/category")]
    public async Task<IActionResult> RemoveMenuItemFromCategory(Guid menuitemid)
    {
        var result = await _menuItemService.RemoveMenuItemCategoryAsync(menuitemid);
        return Content(result);
    }

    [SwaggerOperation(Summary = "Delete an menu item")]
    [HttpDelete("{menuitemid}")]
    public async Task<IActionResult> DeleteMenuItem(Guid menuitemid)
    {
        var result = await _menuItemService.DeleteMenuItemAsync(menuitemid);
        return Content(result);
    }

    [SwaggerOperation(Summary = "Add customize options to menu.")]
    [HttpPatch("{menuitemid}/customize-options")]
    public async Task<IActionResult> AddCustomizeOptionsToMenu(Guid menuitemid, [FromBody] Guid customizeOptionsId)
    {
        var result = await _menuItemService.AddCustomizeOptionsToMenuAsync(menuitemid, customizeOptionsId);
        return Content(result);
    }

    [SwaggerOperation(Summary = "Remove customize options from menu item.")]
    [HttpDelete("{menuitemid}/customize-options")]
    public async Task<IActionResult> RemoveCustomizeOptionsFromMenu(Guid menuitemid, [FromBody] Guid customizeOptionsId)
    {
        var result = await _menuItemService.RemoveCustomizeOptionsFromMenuAsync(menuitemid, customizeOptionsId);
        return Content(result);
    }
}