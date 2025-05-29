namespace RestaurantManagementApp.DbService.Tables;

public class TblBookingSlot
{
    public Guid Id { get; set; }
    public string SlotNumber { get; set; }
    public DateOnly BookingDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string IsAvailable { get; set; }
}