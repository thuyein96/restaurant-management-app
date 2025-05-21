using RestaurantManagementApp.DbService.Tables;

namespace RestaurantManagementApp.Dtos.Features.CustomizeOption;

public class MenuItemCustomizeOptionDto
{
    public Guid MenuItemCustomizeOptionId { get; set; }
    public Guid MenuItemId { get; set; }
    public Guid CustomizeOptionId { get; set; }
    public TblMenuItem MenuItem { get; set; }
    public TblCustomizeOption CustomizeOption { get; set; }
}