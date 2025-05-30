namespace RestaurantManagementApp.Modules.Features.BookingSlot;

public interface IBookingSlotService
{
    Task<Result<IEnumerable<BookingSlotDto>>> GetBookingSlotsAsync();
    Task<Result<BookingSlotDto>> GetBookingSlotByIdAsync(Guid bookingSlotId);
    Task<Result<BookingSlotDto>> GetBookingSlotBySlotNumberAsync(string slotNumber);
    Task<Result<BookingSlotDto>> CreateBookingSlotAsync(CreateBookingSlotDto createBookingSlot);
    Task<Result<BookingSlotDto>> UpdateBookingSlotAsync(Guid bookingSlotId, UpdateBookingSlotDto updateBookingSlotDto);
    Task<Result<BookingSlotDto>> DeleteBookingSlotAsync(Guid bookingSlotId);
}