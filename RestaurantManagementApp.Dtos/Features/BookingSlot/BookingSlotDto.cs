namespace RestaurantManagementApp.Dtos.Features.BookingSlot;

public class BookingSlotDto
{
    public Guid Id { get; set; }
    public string SlotNumber { get; set; }
    public DateOnly BookingDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public BookingSlotStatus IsAvailable { get; set; }
}