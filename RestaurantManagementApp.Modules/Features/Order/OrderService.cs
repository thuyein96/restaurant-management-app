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
            var calculatedOrder = await CreateOrderDtoWithTotalAmount(createOrderDto);

            var newOrder = await _appDbContext.TblOrders.AddAsync(calculatedOrder.ToEntity());
            await _appDbContext.SaveChangesAsync();

            result = Result<OrderDto>.SaveSuccess(newOrder.Entity.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<OrderDto>.Failure(ex);
        }

        return result;
    }

    private async Task<OrderDto> CreateOrderDtoWithTotalAmount(CreateOrderDto createOrderDto)
    {
        var order = new OrderDto()
        {
            CustomerId = createOrderDto.CustomerId,
            OrderDate = createOrderDto.OrderDate,
            OrderDetails = await CalculatedOrderItems(createOrderDto)
        };
        decimal totalAmount = await CalculateOrder(order);
        order.TotalAmount = totalAmount;
        return order;
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

            var updatedOrder = _appDbContext.TblOrders.Update(order);
            await _appDbContext.SaveChangesAsync();

            result = Result<OrderDto>.UpdateSuccess(updatedOrder.Entity.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<OrderDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<OrderDto>> UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
    {
        Result<OrderDto> result;
        try
        {
            var order = await GetSpecificOrder(x => x.Id == orderId);
            if (order is null)
            {
                result = Result<OrderDto>.NotFound("Order Not Found.");
                return result;
            }
            
            order.OrderStatus = status.Name;
            var updatedOrder = _appDbContext.TblOrders.Update(order);
            result = Result<OrderDto>.UpdateSuccess(updatedOrder.Entity.ToDto());
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

            var removedOrder = _appDbContext.TblOrders.Remove(order);
            await _appDbContext.SaveChangesAsync();

            result = Result<OrderDto>.DeleteSuccess(removedOrder.Entity.ToDto());
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

    private async Task<List<OrderDetailsDto>> CalculatedOrderItems(CreateOrderDto order)
    {
        var orderItems = new List<OrderDetailsDto>();
        foreach (var item in order.OrderItems)
        {
            var orderItem = new OrderDetailsDto
            {
                OrderId = item.OrderId,
                MenuItemId = item.MenuItemId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                SubTotal = await CalculateOrderItem(item)
            };
            orderItems.Add(orderItem);
        }

        return orderItems;
    }

    private async Task<decimal> CalculateOrder(OrderDto orders)
    {
        return orders.OrderDetails.Sum(x => x.SubTotal);
    }

    private async Task<decimal> CalculateOrderItem(CreateOrderDetailsDto orderItem)
    {
        return orderItem.Quantity * orderItem.UnitPrice;
    }
}