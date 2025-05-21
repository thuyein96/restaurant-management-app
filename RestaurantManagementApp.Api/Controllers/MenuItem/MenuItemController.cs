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

    [HttpGet]
    public async Task<IActionResult> GetMenuItems()
    {
        var result = await _menuItemService.GetMenuItemsAsync();
        return Content(result);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetMenuItemById(Guid id)
    {
        var result = await _menuItemService.GetMenuItemByIdAsync(id);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenuItem(
        [FromBody] CreateMenuItemDto menuItemDto
    )
    {
        var result = await _menuItemService.CreateMenuItemAsync(menuItemDto);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenuItem(
        Guid id,
        [FromBody] UpdateMenuItemDto menuItemDto
    )
    {
        var result = await _menuItemService.UpdateMenuItemAsync(id, menuItemDto);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenuItem(Guid id)
    {
        var result = await _menuItemService.DeleteMenuItemAsync(id);
        return Content(result);
    }
}