namespace RestaurantManagementApp.Utils.Enum;

public class QueueStatus : SmartEnum<QueueStatus>
{
    public static readonly QueueStatus Waiting = new QueueStatus("Waiting", 1);
    public static readonly QueueStatus Served = new QueueStatus("Served", 2);
    public static readonly QueueStatus Cancelled = new QueueStatus("Cancelled", 3);
    public QueueStatus(string name, int value) : base(name, value)
    {
    }
}