namespace RestaurantManagementApp.Modules.Features.Order;

public class OrderService : IOrderService
{
    private readonly AppDbContext _appDbContext;

    public OrderService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Result<OrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        Result<OrderDto> result;
        try
        {
            await _appDbContext.TblOrders.AddAsync(createOrderDto.ToEntity());
            await _appDbContext.SaveChangesAsync();

            result = Result<OrderDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<OrderDto>.Failure(ex);
        }

        return result;
    }



    public async Task<Result<OrderDto>> GetOrderByIdAsync(Guid orderId)
    {
        Result<OrderDto> result;
        try
        {
            var order = await GetSpecificOrder(
                x => x.Id == orderId
            );
            if (order is null)
            {
                result = Result<OrderDto>.NotFound("Order Not Found.");
                return result;
            }

            result = Result<OrderDto>.Success(order.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<OrderDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<IEnumerable<OrderDto>>> GetAllOrdersAsync()
    {
        Result<IEnumerable<OrderDto>> result;
        try
        {
            var lst = await _appDbContext
                .TblOrders
                .ToListAsync();
            result = Result<IEnumerable<OrderDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<OrderDto>>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<OrderDto>> UpdateOrderAsync(UpdateOrderDto updateOrderDto)
    {
        Result<OrderDto> result;
        try
        {
            var order = await GetSpecificOrder(x => x.Id == updateOrderDto.OrderId);
            if (order is null)
            {
                result = Result<OrderDto>.NotFound("Order Not Found.");
                return result;
            }


            order.CustomerId = updateOrderDto.CustomerId;
            order.OrderDate = updateOrderDto.OrderDate;
            order.TotalAmount = updateOrderDto.TotalAmount;
            order.OrderDetails = updateOrderDto.OrderItems.Select(x => x.ToEntity()).ToList();

            _appDbContext.TblOrders.Update(order);
            await _appDbContext.SaveChangesAsync();

            result = Result<OrderDto>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            result = Result<OrderDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<OrderDto>> DeleteOrderAsync(Guid orderId)
    {
        Result<OrderDto> result;
        try
        {
            var order = await GetSpecificOrder(
                x => x.Id == orderId
            );
            if (order is null)
            {
                result = Result<OrderDto>.NotFound("Order Not Found.");
                return result;
            }

            _appDbContext.TblOrders.Remove(order);
            await _appDbContext.SaveChangesAsync();

            result = Result<OrderDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<OrderDto>.Failure(ex);
        }

        return result;
    }


    public async Task<List<OrderDetailsDto>> GetOrderDetailsByOrderIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    private async Task<bool?> IsOrderDuplicate(
        Expression<Func<TblOrder, bool>> expression
        )
    {
        return await _appDbContext.TblOrders.AnyAsync(
            expression
        );
    }

    private async Task<TblOrder?> GetSpecificOrder(
        Expression<Func<TblOrder, bool>> expression
    )
    {
        return await _appDbContext.TblOrders.FirstOrDefaultAsync(
            expression
        );
    }
}