namespace RestaurantManagementApp.Dtos.Features.Queue;

public class UpdateQueueDto
{
    public Guid QueueId { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string NumberofPeople { get; set; }
    public string QueueStatus { get; set; }
}