namespace RestaurantManagementApp.Api.Controllers.Queue;

[Route("api/[controller]")]
[ApiController]
public class QueueController : BaseController
{
    private readonly IQueueService _queueService;

    public QueueController(IQueueService queueService)
    {
        _queueService = queueService;
    }
    
    [SwaggerOperation(Summary = "Get All Queue Items")]
    [HttpGet]
    public async Task<IActionResult> GetAllQueues()
    {
        var result = await _queueService.GetAllQueuesAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get Queues by Restaurant Id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetQueueById(Guid id)
    {
        var result = await _queueService.GetQueueByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get Queue by Customer Name")]
    [HttpGet("{customerName}")]
    public async Task<IActionResult> GetQueueByCustomerName(string customerName)
    {
        var result = await _queueService.GetQueueByCustomerNameAsync(customerName);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Create New Queue Item")]
    [HttpPost]
    public async Task<IActionResult> CreateQueue(
        [FromBody] CreateQueueDto createQueue
    )
    {
        var result = await _queueService.CreateQueueAsync(createQueue);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Update Existing Queue Item")]
    [HttpPut]
    public async Task<IActionResult> UpdateQueue(
        [FromBody] UpdateQueueDto updateQueue
    )
    {
        var result = await _queueService.UpdateQueueAsync(updateQueue);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Delete Queue Item")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQueue(Guid id)
    {
        var result = await _queueService.DeleteQueueAsync(id);
        return Content(result);
    }
}