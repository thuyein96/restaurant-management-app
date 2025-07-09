namespace RestaurantManagementApp.Dtos.Features.Reservation;

public class ReservationDto
{
    public Guid Id { get; set; }
    public string ReservationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NumberOfPeople { get; set; }
    public string SpecialRequest { get; set; }
    public bool IsConfirm { get; set; }
    public Guid BookingSlotId { get; set; }
    public Guid TableId { get; set; }
}