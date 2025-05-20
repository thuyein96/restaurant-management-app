namespace RestaurantManagementApp.DbService.Tables;

public class TblCustomizeOption
{
    [Key]
    public Guid CustomizeOptionId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<TblMenuItemCustomizeOption> MenuItemCustomizeOptions { get; set; }
}