namespace RestaurantManagementApp.Api.Controllers.CustomizeOption;

[Route("api/[controller]")]
[ApiController]
public class CustomizeOptionController : BaseController
{
    private readonly ICustomizeOptionService _customizeOptionService;

    public CustomizeOptionController(ICustomizeOptionService customizeOptionService)
    {
        _customizeOptionService = customizeOptionService;
    }
    
    [SwaggerOperation(Summary = "Get all customize options")]
    [HttpGet]
    public async Task<IActionResult> GetCustomizeOptions()
    {
        var result = await _customizeOptionService.GetCustomizeOptionsAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get customize option by id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomizeOptionById(Guid id)
    {
        var result = await _customizeOptionService.GetCustomizeOptionByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Create a customize option")]
    [HttpPost]
    public async Task<IActionResult> CreateCustomizeOption(
        [FromBody] CreateCustomizeOptionDto createCustomizeOptionDto
    )
    {
        var result = await _customizeOptionService.CreateCustomizeOptionAsync(createCustomizeOptionDto);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Update an existing customize option")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomizeOption(
        Guid id,
        [FromBody] UpdateCustomizeOptionDto updateCustomizeOptionDto
    )
    {
        var result = await _customizeOptionService.UpdateCustomizeOptionAsync(id, updateCustomizeOptionDto);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Delete a customize option")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomizeOption(Guid id)
    {
        var result = await _customizeOptionService.DeleteCustomizeOptionAsync(id);
        return Content(result);
    }
}