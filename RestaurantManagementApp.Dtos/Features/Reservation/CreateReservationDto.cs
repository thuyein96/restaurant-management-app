namespace RestaurantManagementApp.Dtos.Features.Reservation;

public class CreateReservationDto
{
    public int NumberOfPeople { get; set; }
    public string SpecialRequest { get; set; }
    public bool IsConfirm { get; set; }
    public Guid BookingSlotId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid TableId { get; set; }
}