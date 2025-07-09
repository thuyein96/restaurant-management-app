namespace RestaurantManagementApp.Modules.Features.Reservation;

public class ReservationService : IReservationService
{
    private readonly AppDbContext _dbContext;

    public ReservationService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<IEnumerable<ReservationDto>>> GetReservationsAsync()
    {
        Result<IEnumerable<ReservationDto>> result;
        try
        {
            var lst = await _dbContext
                .TblReservations
                .Include(x => x.Table)
                .ToListAsync();
            result = Result<IEnumerable<ReservationDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<ReservationDto>>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<ReservationDto>> GetReservationByIdAsync(Guid reservationId)
    {
        Result<ReservationDto> result;
        try
        {
            var reservation = await GetSpecificReservation(
                x => x.Id == reservationId
            );
            if (reservation is null)
            {
                result = Result<ReservationDto>.NotFound("Reservation Not Found.");
                return result;
            }

            result = Result<ReservationDto>.Success(reservation.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<ReservationDto>.Failure(ex);
        }

        return result;
    }
    
    public async Task<Result<ReservationDto>> CreateReservationAsync(CreateReservationDto reservationDto)
    {
        Result<ReservationDto> result;
        try
        {
            bool isTableBooked = await IsTableBooked(
                x => x.TableId == reservationDto.TableId &&
                     x.BookingSlotId == reservationDto.BookingSlotId
            );
            if (isTableBooked)
            {
                result = Result<ReservationDto>.Duplicate("Table is already booked for this slot.");
                return result;
            }

            await ChangeTableStatusAsync(reservationDto.TableId);
            await ChangeBookingSlotStatusAsync(reservationDto.BookingSlotId);

            await _dbContext.TblReservations.AddAsync(reservationDto.ToEntity());
            await _dbContext.SaveChangesAsync();

            result = Result<ReservationDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<ReservationDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<ReservationDto>> UpdateReservationAsync(
        Guid reservationId,
        UpdateReservationDto updateReservationDto)
    {
        Result<ReservationDto> result;
        try
        {
            var reservation = await GetSpecificReservation(
                x => x.Id == reservationId
            );
            if (reservation is null)
            {
                result = Result<ReservationDto>.NotFound("Reservation Not Found.");
                return result;
            }

            if (updateReservationDto.TableId != reservation.TableId ||
                updateReservationDto.BookingSlotId != reservation.BookingSlotId)
            {
                bool isTableBooked = await IsTableBooked(
                    x => x.TableId == updateReservationDto.TableId &&
                         x.BookingSlotId == updateReservationDto.BookingSlotId &&
                         x.Id != reservationId
                );
                if (isTableBooked)
                {
                    result = Result<ReservationDto>.Duplicate("Table is already booked for this slot.");
                    return result;
                }
            }

            _dbContext.TblReservations.Update(
                updateReservationDto
                    .ToEntity(reservation)
                );
            await _dbContext.SaveChangesAsync();

            result = Result<ReservationDto>.Success(reservation.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<ReservationDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<ReservationDto>> DeleteReservationAsync(Guid reservationId)
    {
        Result<ReservationDto> result;
        try
        {
            var reservation = await GetSpecificReservation(
                x => x.Id == reservationId
            );
            if (reservation is null)
            {
                result = Result<ReservationDto>.NotFound("Reservation Not Found.");
                return result;
            }

            _dbContext.TblReservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();

            result = Result<ReservationDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<ReservationDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<IEnumerable<ReservationDto>>> GetReservationsWithQueryValuesAsync(string? reservationNumber, DateOnly? date)
    {
        Result<IEnumerable<ReservationDto>> result;
        try
        {
            var reservations = await QueryReservationsWithGivenValue(reservationNumber, date);


            result = Result<IEnumerable<ReservationDto>>.Success(reservations.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<ReservationDto>>.Failure(ex);
        }

        return result;
    }

    private async Task ChangeTableStatusAsync(Guid tableId)
    {
        var table = await _dbContext.TblTables.FindAsync(tableId);
        if (table != null)
        {
            table.IsAvailable = TableStatus.Reserved.Name;
            _dbContext.TblTables.Update(table);
            await _dbContext.SaveChangesAsync();
        }
    }

    private async Task ChangeBookingSlotStatusAsync(Guid bookingSlotId)
    {
        var bookingSlot = await _dbContext.TblBookingSlots.FindAsync(bookingSlotId);
        if (bookingSlot != null)
        {
            bookingSlot.IsAvailable = BookingSlotStatus.Confirmed.Name;
            _dbContext.TblBookingSlots.Update(bookingSlot);
            await _dbContext.SaveChangesAsync();
        }
    }

    private async Task<List<TblReservation>> QueryReservationsWithGivenValue(string? reservationNumber, DateOnly? date)
    {
        var reservations = new List<TblReservation>();
        if (string.IsNullOrWhiteSpace(reservationNumber))
        {
            reservations = await _dbContext.TblReservations
                .Include(x => x.Table)
                .Where(x => x.ReservationNumber == reservationNumber)
                .ToListAsync();
        }
        else if (date is not null)
        {
            reservations = await _dbContext.TblReservations
                .Include(x => x.Table)
                .Include(x => x.BookingSlot)
                .Where(x => x.BookingSlot.BookingDate == date)
                .ToListAsync();
        }
        else
        {
            reservations = await _dbContext.TblReservations
                .Include(x => x.Table)
                .Include(x => x.BookingSlot)
                .Where(x => x.ReservationNumber == reservationNumber && x.BookingSlot.BookingDate == date)
                .ToListAsync();
        }

        return reservations;
    }
    
    private async Task<bool> IsTableBooked(
        Expression<Func<TblReservation, bool>> expression
    )
    {
        return await _dbContext.TblReservations.AnyAsync(
            expression
        );
    }

    private async Task<TblReservation?> GetSpecificReservation(
        Expression<Func<TblReservation, bool>> expression
    )
    {
        return await _dbContext.TblReservations
            .Include(x => x.Table)
            .FirstOrDefaultAsync(expression);
    }
}
