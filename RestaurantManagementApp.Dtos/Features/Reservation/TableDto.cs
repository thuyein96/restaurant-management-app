namespace RestaurantManagementApp.Dtos.Features.Reservation;

public class TableDto
{
    public string TableNumber { get; set; }
    public TableStatus IsAvailable { get; set; }
}