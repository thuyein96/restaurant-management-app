namespace RestaurantManagementApp.Modules.Features.Cart;

public interface ICartService
{
    Task<Result<IEnumerable<CartDto>>> GetCartsAsync();
    Task<Result<CartDto>> GetCartByIdAsync(Guid cartId);
    Task<Result<CartDto>> GetCartByCustomerIdAsync(Guid customerId);
    Task<Result<CartDto>> CreateCartAsync(CreateCartDto cartDto);
    Task<Result<CartDto>> UpdateCartAsync(Guid cartId, UpdateCartDto cartDto);
    Task<Result<CartItemDto>> AddCartItemAsync(Guid cartId, CreateCartItemDto cartItemDto);
    Task<Result<CartItemDto>> RemoveCartItemAsync(Guid cartId, Guid cartItemId);
    Task<Result<CartItemDto>> UpdateCartItemAsync(Guid cartId, UpdateCartItemDto cartItemDto);
    Task<Result<CartDto>> DeleteCartAsync(Guid cartId);
}