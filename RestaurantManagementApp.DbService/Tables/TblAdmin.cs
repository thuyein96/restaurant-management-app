namespace RestaurantManagementApp.DbService.Tables;

public class TblAdmin
{
    public Guid Id { get; set;  }
    public string HashedPassword { get; set; }
    public Guid UserId { get; set; }
    public TblUser User { get; set; }
}