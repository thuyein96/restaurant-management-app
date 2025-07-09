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
    
    [SwaggerOperation(Summary = "Get all categories")]
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var result = await _categoryService.GetCategoriesAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get category by id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Create a new category")]
    [HttpPost]
    public async Task<IActionResult> CreateCategory(
        [FromBody] CreateCategoryDto categoryDto
    )
    {
        var result = await _categoryService.CreateCategoryAsync(categoryDto);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Update an existing category")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return Content(result);
    }
}