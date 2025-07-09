namespace RestaurantManagementApp.DbService.Tables;

public class TblMenuItem
{
    [Key]
    public Guid MenuItemId { get; set; }
    public string MenuItemName { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public string? ImageUrl { get; set; }
    public Guid? CategoryId { get; set; }
    public TblCategory? Category { get; set; }
    public ICollection<TblMenuItemCustomizeOption>? MenuItemCustomizeOptions { get; set; } 
}