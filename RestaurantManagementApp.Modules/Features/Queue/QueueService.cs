namespace RestaurantManagementApp.Modules.Features.Queue;

public class QueueService : IQueueService
{
    private readonly AppDbContext _dbContext;
    private readonly IHubContext<QueueHub> _hubContext;

    public QueueService(AppDbContext appDbContext, IHubContext<QueueHub> hubContext)
    {
        _dbContext = appDbContext;
        _hubContext = hubContext;
    }
    public async Task<Result<QueueDto>> CreateQueueAsync(CreateQueueDto createQueueDto)
    {
        Result<QueueDto> result;
        try
        {
            bool isDuplicate = await IsQueueDuplicate(
                x => x.CustomerName == createQueueDto.CustomerName
            );
            if (isDuplicate)
            {
                result = Result<QueueDto>.Duplicate("Queue with this customer name already exists.");
                return result;
            }

            await _dbContext.TblQueues.AddAsync(createQueueDto.ToEntity());
            await _dbContext.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("QueueUpdated");

            result = Result<QueueDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<QueueDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<QueueDto>> UpdateQueueAsync(UpdateQueueDto updateQueueDto)
    {
        Result<QueueDto> result;
        try
        {
            if (updateQueueDto.QueueStatus != QueueStatus.Served.Name)
            {
                return Result<QueueDto>
                    .Failure("Queue status must be 'Served' to update the queue.");
            }
            var queue = await GetSpecificQueue(x => x.Id == updateQueueDto.QueueId);
            if (queue is null)
            {
                return Result<QueueDto>
                    .NotFound("Queue Not Found.");
            }

            bool isDuplicate = await IsQueueDuplicate(
                x => x.CustomerName == updateQueueDto.CustomerName && x.Id != updateQueueDto.QueueId
            );
            if (isDuplicate)
            {
                result = Result<QueueDto>.Duplicate("Menu Item Name already exists.");
                return result;
            }

            _dbContext.TblQueues.Update(updateQueueDto.ToEntity(queue));
            await _dbContext.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("QueueUpdated");

            result = Result<QueueDto>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            result = Result<QueueDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<QueueDto>> DeleteQueueAsync(Guid queueId)
    {
        Result<QueueDto> result;
        try
        {
            var queue = await GetSpecificQueue(
                x => x.Id == queueId
            );
            if (queue is null)
            {
                result = Result<QueueDto>.NotFound("Queue Not Found.");
                return result;
            }

            _dbContext.TblQueues.Remove(queue);
            await _dbContext.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("QueueUpdated");

            result = Result<QueueDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<QueueDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<QueueDto>> GetQueueByIdAsync(Guid queueId)
    {
        Result<QueueDto> result;
        try
        {
            var queue = await GetSpecificQueue(x => x.Id == queueId);
            if (queue is null)
            {
                result = Result<QueueDto>.NotFound("Queue Not Found.");
                return result;
            }
            result = Result<QueueDto>.Success(queue.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<QueueDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<QueueDto>> GetQueueByCustomerNameAsync(string customerName)
    {
        Result<QueueDto> result;
        try
        {
            var queue = await GetSpecificQueue(x => x.CustomerName == customerName);
            if (queue is null)
            {
                result = Result<QueueDto>.NotFound($"Queue with {customerName} is not fund.");
                return result;
            }
            result = Result<QueueDto>.Success(queue.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<QueueDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<IEnumerable<QueueDto>>> GetAllQueuesAsync()
    {
        Result<IEnumerable<QueueDto>> result;
        try
        {
            var queues = await _dbContext.TblQueues.ToListAsync();
            if (queues is null || !queues.Any())
            {
                result = Result<IEnumerable<QueueDto>>.NotFound("No queues found.");
                return result;
            }
            var queueDtos = queues.Select(q => q.ToDto());
            result = Result<IEnumerable<QueueDto>>.Success(queueDtos);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<QueueDto>>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<IEnumerable<QueueDto>>> GetQueuesByRestaurantIdAsync(Guid restaurantId)
    {
        Result<IEnumerable<QueueDto>> result;
        try
        {
            var queues = await _dbContext.TblQueues
                .Where(q => q.RestaurantId == restaurantId)
                .ToListAsync();
            if (queues is null || !queues.Any())
            {
                result = Result<IEnumerable<QueueDto>>.NotFound("No queues found for this restaurant.");
                return result;
            }
            var queueDtos = queues.Select(q => q.ToDto());
            result = Result<IEnumerable<QueueDto>>.Success(queueDtos);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<QueueDto>>.Failure(ex);
        }

        return result;
    }


    private async Task<bool> IsQueueDuplicate(
        Expression<Func<TblQueue, bool>> expression
    )
    {
        return await _dbContext.TblQueues.AnyAsync(
            expression
        );
    }

    private async Task<TblQueue?> GetSpecificQueue(
        Expression<Func<TblQueue, bool>> expression
    )
    {
        return await _dbContext.TblQueues.FirstOrDefaultAsync(
            expression
        );
    }
}