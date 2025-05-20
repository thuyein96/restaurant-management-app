namespace RestaurantManagementApp.DbService.Tables;

public class TblCategory
{
    [Key]
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }

}