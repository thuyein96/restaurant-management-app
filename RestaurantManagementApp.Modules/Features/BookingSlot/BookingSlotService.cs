namespace RestaurantManagementApp.Modules.Features.BookingSlot;

public class BookingSlotService : IBookingSlotService
{
    private readonly AppDbContext _appDbContext;

    public BookingSlotService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Result<IEnumerable<BookingSlotDto>>> GetBookingSlotsAsync()
    {
        Result<IEnumerable<BookingSlotDto>> result;
        try
        {
            var lst = await _appDbContext
                .TblBookingSlots
                .ToListAsync();
            result = Result<IEnumerable<BookingSlotDto>>.Success(lst.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<BookingSlotDto>>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<BookingSlotDto>> GetBookingSlotByIdAsync(Guid bookingSlotId)
    {
        Result<BookingSlotDto> result;
        try
        {
            var bookingSlot = await _appDbContext
                .TblBookingSlots
                .FirstOrDefaultAsync(x => x.Id == bookingSlotId);
            if (bookingSlot is null)
            {
                result = Result<BookingSlotDto>.NotFound("Booking Slot Not Found.");
                return result;
            }
            result = Result<BookingSlotDto>.Success(bookingSlot.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<BookingSlotDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<BookingSlotDto>> GetBookingSlotBySlotNumberAsync(string slotNumber)
    {
        Result<BookingSlotDto> result;
        try
        {
            var bookingSlot = await _appDbContext
                .TblBookingSlots
                .FirstOrDefaultAsync(x => x.SlotNumber == slotNumber);
            if (bookingSlot is null)
            {
                result = Result<BookingSlotDto>.NotFound("Booking Slot Not Found.");
                return result;
            }
            result = Result<BookingSlotDto>.Success(bookingSlot.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<BookingSlotDto>.Failure(ex);
        }
        return result;
    }

    public async Task<Result<BookingSlotDto>> CreateBookingSlotAsync(CreateBookingSlotDto createBookingSlot)
    {
        Result<BookingSlotDto> result;
        try
        {
            var isDuplicate = await _appDbContext
                .TblBookingSlots
                .AnyAsync(x => x.StartTime == Converter.ToTime(createBookingSlot.StartTime) &&
                               x.BookingDate == Converter.ToDate(createBookingSlot.BookingDate));
            if (isDuplicate)
            {
                result = Result<BookingSlotDto>.Failure("Booking Slot already exists for the given date and time.");
                return result;
            }
            await _appDbContext
                .TblBookingSlots
                .AddAsync(createBookingSlot.ToEntity());
            await _appDbContext.SaveChangesAsync();

            result = Result<BookingSlotDto>.Success();
        }
        catch (Exception ex)
        {
            result = Result<BookingSlotDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<BookingSlotDto>> UpdateBookingSlotAsync(Guid bookingSlotId, UpdateBookingSlotDto updateBookingSlotDto)
    {
        Result<BookingSlotDto> result;
        try
        {
            var bookingSlot = await _appDbContext
                .TblBookingSlots
                .FirstOrDefaultAsync(x => x.Id == bookingSlotId);
            if (bookingSlot is null)
            {
                result = Result<BookingSlotDto>.NotFound("Booking Slot Not Found.");
                return result;
            }

            _appDbContext.TblBookingSlots.Update(updateBookingSlotDto.ToEntity(bookingSlot));
            await _appDbContext.SaveChangesAsync();
            result = Result<BookingSlotDto>.Success(bookingSlot.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<BookingSlotDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<BookingSlotDto>> DeleteBookingSlotAsync(Guid bookingSlotId)
    {
        Result<BookingSlotDto> result;
        try
        {
            var bookingSlot = await _appDbContext
                .TblBookingSlots
                .FirstOrDefaultAsync(x => x.Id == bookingSlotId);
            if (bookingSlot is null)
            {
                result = Result<BookingSlotDto>.NotFound("Booking Slot Not Found.");
                return result;
            }

            _appDbContext.TblBookingSlots.Remove(bookingSlot);
            await _appDbContext.SaveChangesAsync();
            result = Result<BookingSlotDto>.Success(bookingSlot.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<BookingSlotDto>.Failure(ex);
        }
        return result;
    }
}