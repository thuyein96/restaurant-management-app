namespace RestaurantManagementApp.Utils.Enum;

public class QueueStatus : SmartEnum<QueueStatus>
{
    public static readonly QueueStatus InLine = new QueueStatus("InLine", 1);
    public static readonly QueueStatus Active = new QueueStatus("Active", 2);
    public static readonly QueueStatus Cancelled = new QueueStatus("Cancelled", 3);
    public QueueStatus(string name, int value) : base(name, value)
    {
    }
}