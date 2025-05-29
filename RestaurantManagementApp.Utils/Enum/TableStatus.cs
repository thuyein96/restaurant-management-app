namespace RestaurantManagementApp.Utils.Enum;

public sealed class TableStatus : SmartEnum<TableStatus>
{
    public static readonly TableStatus Available = new TableStatus("Available", 1);
    public static readonly TableStatus Taken = new TableStatus("Taken", 2);
    public static readonly TableStatus Reserved = new TableStatus("Reserved", 3);

    private TableStatus(string name, int value) : base(name, value)
    {
    }
}
