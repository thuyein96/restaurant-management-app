namespace RestaurantManagementApp.DbService.Tables;

public class TblCart
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public TblCustomer Customer { get; set; }
    public ICollection<TblCartItem>? CartItems { get; set; }
    public int Total { get; set; }
}