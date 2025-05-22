using RestaurantManagementApp.Dtos.Features.CustomizeOption;
using RestaurantManagementApp.Modules.Features.CustomizeOption;

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

    [HttpGet]
    public async Task<IActionResult> GetCustomizeOptions()
    {
        var result = await _customizeOptionService.GetCustomizeOptionsAsync();
        return Content(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomizeOptionById(Guid id)
    {
        var result = await _customizeOptionService.GetCustomizeOptionByIdAsync(id);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomizeOption(
        [FromBody] CreateCustomizeOptionDto createCustomizeOptionDto
    )
    {
        var result = await _customizeOptionService.CreateCustomizeOptionAsync(createCustomizeOptionDto);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomizeOption(
        Guid id,
        [FromBody] UpdateCustomizeOptionDto updateCustomizeOptionDto
    )
    {
        var result = await _customizeOptionService.UpdateCustomizeOptionAsync(id, updateCustomizeOptionDto);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomizeOption(Guid id)
    {
        var result = await _customizeOptionService.DeleteCustomizeOptionAsync(id);
        return Content(result);
    }
}