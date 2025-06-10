using RestaurantManagementApp.Dtos.Features.Reservation;

namespace RestaurantManagementApp.Extension.Mapping.Reservation;

public static class ReservationMapper
{
    public static ReservationDto ToDto(this TblReservation reservation)
    {
        return new ReservationDto
        {
            Id = reservation.Id,
            NumberOfPeople = reservation.NumberOfPeople,
            SpecialRequest = reservation.SpecialRequest,
            IsConfirm = reservation.IsConfirm,
            BookingSlotId = reservation.BookingSlotId,
            CustomerId = reservation.CustomerId,
            TableId = reservation.TableId,
            // Add any additional mappings here
        };
    }

    public static TblReservation ToEntity(this CreateReservationDto dto)
    {
        return new TblReservation
        {
            Id = Guid.NewGuid(),
            NumberOfPeople = dto.NumberOfPeople,
            SpecialRequest = dto.SpecialRequest,
            IsConfirm = false,
            BookingSlotId = dto.BookingSlotId,
            CustomerId = dto.CustomerId,
            TableId = dto.TableId
        };
    }

    public static TblReservation ToEntity(this UpdateReservationDto dto, TblReservation reservation)
    {
        reservation.NumberOfPeople = dto.NumberOfPeople;
        reservation.SpecialRequest = dto.SpecialRequest;
        reservation.TableId = dto.TableId;
        reservation.BookingSlotId = dto.BookingSlotId;
        reservation.IsConfirm = dto.IsConfirm;
        return reservation;
    }
}