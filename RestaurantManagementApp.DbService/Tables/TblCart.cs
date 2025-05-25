namespace RestaurantManagementApp.DbService.Tables;

public class TblCart
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public TblUser User { get; set; }
    public int Total { get; set; }
}