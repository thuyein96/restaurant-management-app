namespace RestaurantManagementApp.DbService.Tables;

public class TblCustomer
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public TblUser User { get; set; }
}