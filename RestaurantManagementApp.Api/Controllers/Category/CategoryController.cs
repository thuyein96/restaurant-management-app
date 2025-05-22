namespace RestaurantManagementApp.Api.Controllers.Category;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var result = await _categoryService.GetCategoriesAsync();
        return Content(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(
        [FromBody] CreateCategoryDto categoryDto
    )
    {
        var result = await _categoryService.CreateCategoryAsync(categoryDto);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return Content(result);
    }
}