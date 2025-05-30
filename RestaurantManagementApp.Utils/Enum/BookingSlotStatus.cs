namespace RestaurantManagementApp.Utils.Enum;

public class BookingSlotStatus : SmartEnum<BookingSlotStatus>
{
    public static readonly BookingSlotStatus Confirmed = new BookingSlotStatus("Confirmed", 1);
    public static readonly BookingSlotStatus Pending = new BookingSlotStatus("Pending", 2);
    public static readonly BookingSlotStatus Cancelled = new BookingSlotStatus("Cancelled", 3);
    public BookingSlotStatus(string name, int value) : base(name, value)
    {
    }
}