namespace RestaurantManagementApp.Api.Controllers.Order;

[Route("api/[controller]")]
[ApiController]
public class OrderController : BaseController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [SwaggerOperation(Summary = "Get all orders")]
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var result = await _orderService.GetAllOrdersAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get order by id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var result = await _orderService.GetOrderByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Create a new order")]
    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        [FromBody] CreateOrderDto createOrder
    )
    {
        var result = await _orderService.CreateOrderAsync(createOrder);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Delete an existing order")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var result = await _orderService.DeleteOrderAsync(id);
        return Content(result);
    }
}