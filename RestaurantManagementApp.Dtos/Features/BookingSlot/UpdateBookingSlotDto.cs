namespace RestaurantManagementApp.Dtos.Features.BookingSlot;

public class UpdateBookingSlotDto
{
    public DateOnly BookingDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public BookingSlotStatus IsAvailable { get; set; }
}