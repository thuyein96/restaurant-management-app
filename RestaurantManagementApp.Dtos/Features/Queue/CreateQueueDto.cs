namespace RestaurantManagementApp.Dtos.Features.Queue;

public class CreateQueueDto
{
    public Guid RestaurantId { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string NumberofPeople { get; set; }
}