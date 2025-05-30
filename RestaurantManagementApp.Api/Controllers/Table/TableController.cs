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

    [HttpGet]
    public async Task<IActionResult> GetTables()
    {
        var result = await _tableService.GetTablesAsync();
        return Content(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTableById(Guid id)
    {
        var result = await _tableService.GetTableByIdAsync(id);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTable([FromBody] string tableNumber)
    {
        var result = await _tableService.CreateTableAsync(tableNumber);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTable(Guid id, [FromBody] TableStatus tableStatus)
    {
        var result = await _tableService.UpdateTableAsync(id, tableStatus);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTable(Guid id)
    {
        var result = await _tableService.DeleteTableAsync(id);
        return Content(result);
    }
}