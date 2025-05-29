namespace RestaurantManagementApp.Dtos.Features.Reservation;

public class TimeSlotDto
{
    public string SlotNumber { get; set; }
    public DateOnly BookingDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public TimeSlotStatus IsAvailable { get; set; }
}