using RestaurantManagementApp.Modules.Helper;

namespace RestaurantManagementApp.Modules.Features.Cart;

public class CartService : ICartService
{
    private readonly AppDbContext _dbContext;

    public CartService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<IEnumerable<CartDto>>> GetCartsAsync()
    {
        Result<IEnumerable<CartDto>> result;
        try
        {
            var lst = await _dbContext
               .TblCarts
               .Include(x => x.Customer)
               .Include(x => x.CartItems)
               .ToListAsync();
            result = Result<IEnumerable<CartDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<CartDto>>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartDto>> GetCartByIdAsync(Guid cartId)
    {
        Result<CartDto> result;
        try
        {
            var isExist = await IsCartDuplicate(x => x.Id == cartId);
            if (!isExist)
            {
                return Result<CartDto>.Failure(new Exception("Cart not found"));
            }

            var cart = await _dbContext
                .TblCarts
                .Include(x => x.Customer)
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync(x => x.Id == cartId);
            
            result = Result<CartDto>.Success(cart.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CartDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartDto>> GetCartByCustomerIdAsync(Guid customerId)
    {
        Result<CartDto> result;
        try
        {
            var cartExist = await GetSpecificCart(x => x.CustomerId == customerId);
            if (cartExist == null)
            {
                return Result<CartDto>.Failure(new Exception("Cart not found for the specified customer"));
            }

            var cart = await _dbContext
                .TblCarts
                .Include(x => x.Customer)
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync(x => x.CustomerId == customerId);
          
            result = Result<CartDto>.Success(cart.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CartDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartDto>> CreateCartAsync(CreateCartDto cartDto)
    {
        Result<CartDto> result;
        try
        {
            bool isDuplicate = await IsCartDuplicate(
                x => x.CustomerId == cartDto.CustomerId
            );

            if (isDuplicate)
            {
                return Result<CartDto>.Failure(new Exception("Cart already exists for this customer"));
            }

            await _dbContext.TblCarts.AddAsync(cartDto.ToEntity());
            await _dbContext.SaveChangesAsync();

            result = Result<CartDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<CartDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartDto>> UpdateCartAsync(Guid cartId, CreateCartDto cartDto)
    {
        Result<CartDto> result;
        try
        {
            var cart = await GetSpecificCart(x => x.Id == cartId);
            if (cart == null)
            {
                return Result<CartDto>.Failure(new Exception("Cart not found"));
            }
            
            cart.CustomerId = cartDto.CustomerId;
            cart.Total = cartDto.Total;
            
            _dbContext.TblCarts.Update(cart);
            await _dbContext.SaveChangesAsync();
            result = Result<CartDto>.Success(cart.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CartDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartItemDto>> AddCartItemAsync(CreateCartItemDto cartItemDto)
    {
        Result<CartItemDto> result;
        try
        {
            var cart = await GetSpecificCart(x => x.Id == cartItemDto.CartId);
            if (cart == null)
            {
                return Result<CartItemDto>.Failure(new Exception("Cart not found"));
            }

            var cartItem = await GetSpecificCartItem(
                x => x.MenuItemId == cartItemDto.MenuItemId
            );
            if (cartItem != null)
            {
                cartItem.Quantity += cartItemDto.Quantity;
                await UpdateCartItem(cartItem);
                return Result<CartItemDto>.Success(cartItem.ToDto());
            }

            await _dbContext.TblCartItems.AddAsync(cartItemDto.ToEntity());
            await _dbContext.SaveChangesAsync();

            result = Result<CartItemDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<CartItemDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartItemDto>> RemoveCartItemAsync(Guid cartId, Guid cartItemId)
    {
        Result<CartItemDto> result;
        try
        {
            var cart = await GetSpecificCart(x => x.Id == cartId);
            if (cart == null)
            {
                return Result<CartItemDto>.Failure(new Exception("Cart not found"));
            }
            var cartItem = await GetSpecificCartItem(x => x.Id == cartItemId);
            if (cartItem == null)
            {
                return Result<CartItemDto>.Failure(new Exception("Cart item not found"));
            }
            _dbContext.TblCartItems.Remove(cartItem);
            await _dbContext.SaveChangesAsync();
            result = Result<CartItemDto>.Success(cartItem.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CartItemDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartItemDto>> UpdateCartItemAsync(Guid cartId, UpdateCartItemDto cartItemDto)
    {
        Result<CartItemDto> result;
        try
        {
            var cart = await GetSpecificCart(x => x.Id == cartId);
            if (cart == null)
            {
                return Result<CartItemDto>.Failure(new Exception("Cart not found"));
            }
            var cartItem = await GetSpecificCartItem(
                x => x.CartId == cartId && x.MenuItemId == cartItemDto.MenuItemId
            );
            if (cartItem == null)
            {
                return Result<CartItemDto>.Failure(new Exception("Cart item not found"));
            }

            cartItem.Quantity = cartItemDto.Quantity;
            await UpdateCartItem(cartItem);
            result = Result<CartItemDto>.Success(cartItem.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CartItemDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<CartDto>> DeleteCartAsync(Guid cartId)
    {
        Result<CartDto> result;
        try
        {
            var cart = await GetSpecificCart(x => x.Id == cartId);
            if (cart == null)
            {
                return Result<CartDto>.Failure(new Exception("Cart not found"));
            }

            var cartItems = await _dbContext.TblCarts
                .Where(x => x.Id == cartId)
                .Include(x => x.CartItems)
                .ToListAsync();

            _dbContext.TblCarts.Remove(cart);
            await _dbContext.SaveChangesAsync();
            result = Result<CartDto>.Success(cart.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<CartDto>.Failure(ex);
        }

        return result;
    }

    private async Task UpdateCartItem(TblCartItem cartItem)
    {
        _dbContext.TblCartItems.Update(cartItem);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<bool> IsCartDuplicate(
        Expression<Func<TblCart, bool>> expression
    )
    {
        return await _dbContext.TblCarts.AnyAsync(
            expression
        );
    }

    private async Task<TblCart?> GetSpecificCart(
        Expression<Func<TblCart, bool>> expression
    )
    {
        return await _dbContext.TblCarts.FirstOrDefaultAsync(
            expression
        );
    }

    private async Task<TblCartItem?> GetSpecificCartItem(
        Expression<Func<TblCartItem, bool>> expression
    )
    {
        return await _dbContext.TblCartItems.FirstOrDefaultAsync(
            expression
        );
    }
}