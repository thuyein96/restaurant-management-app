namespace RestaurantManagementApp.DbService.Tables;

public class TblOrder
{
    public Guid Id { get; set; }
    public Guid? CustomerId { get; set; }
    public TblCustomer? Customer { get; set; }
    public Guid TableId { get; set; }
    public TblTable Table { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<TblOrderDetails> OrderDetails { get; set; }
    public string OrderStatus { get; set; }
}