namespace RestaurantManagementApp.Dtos.Features.BookingSlot;

public class CreateBookingSlotDto
{
    public string SlotNumber { get; set; }
    public string BookingDate { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}