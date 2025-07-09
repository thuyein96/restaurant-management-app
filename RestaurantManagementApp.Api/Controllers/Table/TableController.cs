namespace RestaurantManagementApp.Api.Controllers.Table;

[Route("api/[controller]")]
[ApiController]
public class TableController : BaseController
{
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }
    
    [SwaggerOperation(Summary = "Get all tables")]
    [HttpGet]
    public async Task<IActionResult> GetTables()
    {
        var result = await _tableService.GetTablesAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get table by id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTableById(Guid id)
    {
        var result = await _tableService.GetTableByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get table by number")]
    [HttpPost]
    public async Task<IActionResult> CreateTable(CreateTableDto newtable)
    {
        var result = await _tableService.CreateTableAsync(newtable);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Update an existing table")]
    [HttpPut]
    public async Task<IActionResult> UpdateTable(UpdateTableDto updatetable)
    {
        var result = await _tableService.UpdateTableAsync(updatetable);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Delete a table")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTable(Guid id)
    {
        var result = await _tableService.DeleteTableAsync(id);
        return Content(result);
    }
}