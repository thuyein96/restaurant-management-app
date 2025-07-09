namespace RestaurantManagementApp.DbService.Tables;

public class TblReservation
{
    public Guid Id { get; set; }
    public string ReservationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public int NumberOfPeople { get; set; }
    public string SpecialRequest { get; set; }
    public bool IsConfirm { get; set; }
    public Guid BookingSlotId { get; set; }
    public TblBookingSlot BookingSlot { get; set; }
    public Guid TableId { get; set; }
    public TblTable Table { get; set; }
}