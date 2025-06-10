namespace RestaurantManagementApp.DbService.Tables;

public class TblReservation
{
    public Guid Id { get; set; }
    public int NumberOfPeople { get; set; }
    public string SpecialRequest { get; set; }
    public bool IsConfirm { get; set; }
    public Guid BookingSlotId { get; set; }
    public TblBookingSlot BookingSlot { get; set; }
    public Guid CustomerId { get; set; }
    public TblCustomer Customer { get; set; }
    public Guid TableId { get; set; }
    public TblTable Table { get; set; }
}