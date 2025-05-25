namespace RestaurantManagementApp.DbService.Tables;

public class TblCartItem
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public TblCart Cart { get; set; } 
    public Guid MenuItemId { get; set; }
    public TblMenuItem MenuItem { get; set; }
    public int Quantity { get; set; }
}