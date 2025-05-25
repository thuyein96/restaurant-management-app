namespace RestaurantManagementApp.Modules.Features.Cart;

public interface ICartService
{
    Task<Result<IEnumerable<CartDto>>> GetCartsAsync();
    Task<Result<CartDto>> GetCartByIdAsync(Guid cartId);
    Task<Result<CartDto>> GetCartByCustomerIdAsync(Guid customerId);
    Task<Result<CartDto>> CreateCartAsync(CreateCartDto cartDto);
    Task<Result<CartDto>> UpdateCartAsync(Guid cartId, CreateCartDto cartDto);
    Task<Result<CartDto>> AddCartItemAsync(CreateCartItemDto cartItemDto);
    Task<Result<CartDto>> RemoveCartItemAsync(Guid cartId, Guid cartItemId);
    Task<Result<CartDto>> UpdateCartItemAsync(Guid cartId, UpdateCartItemDto cartItemDto);
    Task<Result<CartDto>> DeleteCartAsync(Guid cartId);
}