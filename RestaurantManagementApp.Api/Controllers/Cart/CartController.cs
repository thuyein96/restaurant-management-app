namespace RestaurantManagementApp.Api.Controllers.Cart;

[Route("api/[controller]")]
[ApiController]
public class CartController : BaseController
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    
    [SwaggerOperation(Summary = "Get all carts")]
    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var result = await _cartService.GetCartsAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get cart by id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCartById(Guid id)
    {
        var result = await _cartService.GetCartByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get cart by customer id")]
    [HttpGet("{customerid}")]
    public async Task<IActionResult> GetCartByCustomerId(Guid customerid)
    {
        var result = await _cartService.GetCartByCustomerIdAsync(customerid);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Create a new cart")]
    [HttpPost]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartDto request)
    {
        var result = await _cartService.CreateCartAsync(request);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Update an existing cart")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCart(
        Guid id, 
        [FromBody] UpdateCartDto request
        )
    {
        var result = await _cartService.UpdateCartAsync(id, request);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Delete a cart")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(Guid id)
    {
        var result = await _cartService.DeleteCartAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get all cart items by cart id")]
    [HttpPost("{cartid}/cartitem")]
    public async Task<IActionResult> AddToCart(Guid cartid, [FromBody] CreateCartItemDto request)
    {
        var result = await _cartService.AddCartItemAsync(cartid, request);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Update cart item by cart id")]
    [HttpPut("{id}/cartitem")]
    public async Task<IActionResult> UpdateCartItem(
        Guid id,
        [FromBody] UpdateCartItemDto request
        )
    {
        var result = await _cartService.UpdateCartItemAsync(id, request);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Remove cart item by cart id and cart item id")]
    [HttpDelete("{cartid}/cartitem/{cartitemid}")]
    public async Task<IActionResult> RemoveCartItem(Guid cartid, Guid cartitemid)
    {
        var result = await _cartService.RemoveCartItemAsync(cartid, cartitemid);
        return Content(result);
    }
}