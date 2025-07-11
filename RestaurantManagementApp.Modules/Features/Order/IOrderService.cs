namespace RestaurantManagementApp.Modules.Features.Order;

public interface IOrderService
{
    Task<Result<OrderDto>> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task<Result<OrderDto>> GetOrderByIdAsync(Guid orderId);
    Task<Result<IEnumerable<OrderDto>>> GetAllOrdersAsync();
    Task<Result<OrderDto>>UpdateOrderAsync(UpdateOrderDto updateOrderDto);
    Task<Result<OrderDto>> UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
    Task<Result<OrderDto>> DeleteOrderAsync(Guid orderId);
    Task<List<OrderDetailsDto>> GetOrderDetailsByOrderIdAsync(Guid orderId);
}