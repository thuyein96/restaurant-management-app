using RestaurantManagementApp.Dtos.Features.Reservation;

namespace RestaurantManagementApp.Extension.Mapping.Reservation;

public static class ReservationMapper
{
    public static ReservationDto ToDto(this TblReservation reservation)
    {
        return new ReservationDto
        {
            Id = reservation.Id,
            ReservationNumber = reservation.ReservationNumber,
            NumberOfPeople = reservation.NumberOfPeople,
            SpecialRequest = reservation.SpecialRequest,
            IsConfirm = reservation.IsConfirm,
            BookingSlotId = reservation.BookingSlotId,
            TableId = reservation.TableId,
        };
    }

    public static TblReservation ToEntity(this CreateReservationDto dto)
    {
        return new TblReservation
        {
            Id = Guid.NewGuid(),
            ReservationNumber = Converter.ReservationNumberGenerator(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            NumberOfPeople = dto.NumberOfPeople,
            SpecialRequest = dto.SpecialRequest,
            IsConfirm = true,
            BookingSlotId = dto.BookingSlotId,
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