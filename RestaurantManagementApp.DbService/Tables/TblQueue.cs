namespace RestaurantManagementApp.DbService.Tables;

public class TblQueue
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string NumberofPeople { get; set; }
    public string QueueStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}