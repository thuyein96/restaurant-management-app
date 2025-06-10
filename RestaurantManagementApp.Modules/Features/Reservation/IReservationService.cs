namespace RestaurantManagementApp.Modules.Features.Reservation;

public interface IReservationService
{
    Task<Result<IEnumerable<ReservationDto>>> GetReservationsAsync();
    Task<Result<ReservationDto>> GetReservationByIdAsync(Guid reservationId);
    Task<Result<ReservationDto>> CreateReservationAsync(CreateReservationDto reservationDto);
    Task<Result<ReservationDto>> UpdateReservationAsync(Guid reservationId, UpdateReservationDto updateReservationDto);
    Task<Result<ReservationDto>> DeleteReservationAsync(Guid reservationId);
    Task<Result<ReservationDto>> ConfirmReservationAsync(Guid reservationId);
    Task<Result<IEnumerable<ReservationDto>>> GetReservationsByCustomerAsync(Guid customerId);
    Task<Result<IEnumerable<ReservationDto>>> GetReservationsByDateAsync(DateOnly date);

}