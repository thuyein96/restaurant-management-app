namespace RestaurantManagementApp.Utils.Enum;

public class TimeSlotStatus : SmartEnum<TimeSlotStatus>
{
    public static readonly TimeSlotStatus Confirmed = new TimeSlotStatus("Confirmed", 1);
    public static readonly TimeSlotStatus Pending = new TimeSlotStatus("Pending", 2);
    public static readonly TimeSlotStatus Cancelled = new TimeSlotStatus("Cancelled", 3);
    public TimeSlotStatus(string name, int value) : base(name, value)
    {
    }
}