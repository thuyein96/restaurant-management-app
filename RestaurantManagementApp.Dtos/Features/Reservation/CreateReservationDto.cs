namespace RestaurantManagementApp.Dtos.Features.Reservation;

public class CreateReservationDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int NumberOfPeople { get; set; }
    public string? SpecialRequest { get; set; }
    public required string Email { get; set; }
    public required int PhoneNumber { get; set; }
    public bool IsConfirm { get; set; }
    public Guid BookingSlotId { get; set; }
    public Guid TableId { get; set; }
}