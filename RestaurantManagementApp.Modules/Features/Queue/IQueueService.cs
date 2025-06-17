namespace RestaurantManagementApp.Modules.Features.Queue;

public interface IQueueService
{
    Task<Result<QueueDto>> CreateQueueAsync(CreateQueueDto createQueueDto);
    Task<Result<QueueDto>> UpdateQueueAsync(UpdateQueueDto updateQueueDto);
    Task<Result<QueueDto>> DeleteQueueAsync(Guid queueId);
    Task<Result<QueueDto>> GetQueueByIdAsync(Guid queueId);
    Task<Result<QueueDto>> GetQueueByCustomerNameAsync(string customerName);
    Task<Result<IEnumerable<QueueDto>>> GetAllQueuesAsync();
    Task<Result<IEnumerable<QueueDto>>> GetQueuesByRestaurantIdAsync(Guid restaurantId);
}