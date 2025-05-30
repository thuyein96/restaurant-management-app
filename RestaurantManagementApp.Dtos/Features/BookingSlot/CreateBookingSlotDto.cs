namespace RestaurantManagementApp.Dtos.Features.BookingSlot;

public class CreateBookingSlotDto
{
    public string SlotNumber { get; set; }
    public DateOnly BookingDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public BookingSlotStatus IsAvailable { get; set; }
}