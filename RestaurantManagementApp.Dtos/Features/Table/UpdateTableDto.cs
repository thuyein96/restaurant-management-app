namespace RestaurantManagementApp.Dtos.Features.Table;

public class UpdateTableDto
{
    public Guid TableId { get; set; }
    public string TableNumber { get; set; }
    public TableStatus Status { get; set; }
}