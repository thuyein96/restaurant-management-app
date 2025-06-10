namespace RestaurantManagementApp.DbService.Tables;

public class TblOrderDetails
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public TblOrder Order { get; set; }
    public Guid MenuItemId { get; set; }
    public TblMenuItem MenuItem { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubTotal { get; set; }
}