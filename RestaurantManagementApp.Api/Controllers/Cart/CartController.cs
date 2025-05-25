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

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var result = await _cartService.GetCartsAsync();
        return Content(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCartById(Guid id)
    {
        var result = await _cartService.GetCartByIdAsync(id);
        return Content(result);
    }

    [HttpGet("{customerid}")]
    public async Task<IActionResult> GetCartByCustomerId(Guid customerid)
    {
        var result = await _cartService.GetCartByCustomerIdAsync(customerid);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartDto request)
    {
        var result = await _cartService.CreateCartAsync(request);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCart(
        Guid id, 
        [FromBody] UpdateCartDto request
        )
    {
        var result = await _cartService.UpdateCartAsync(id, request);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(Guid id)
    {
        var result = await _cartService.DeleteCartAsync(id);
        return Content(result);
    }

    [HttpPost("{cartid}/cartitem")]
    public async Task<IActionResult> AddToCart(Guid cartid, [FromBody] CreateCartItemDto request)
    {
        var result = await _cartService.AddCartItemAsync(cartid, request);
        return Content(result);
    }

    [HttpPut("{id}/cartitem")]
    public async Task<IActionResult> UpdateCartItem(
        Guid id,
        [FromBody] UpdateCartItemDto request
        )
    {
        var result = await _cartService.UpdateCartItemAsync(id, request);
        return Content(result);
    }

    [HttpDelete("{cartid}/cartitem/{cartitemid}")]
    public async Task<IActionResult> RemoveCartItem(Guid cartid, Guid cartitemid)
    {
        var result = await _cartService.RemoveCartItemAsync(cartid, cartitemid);
        return Content(result);
    }
}