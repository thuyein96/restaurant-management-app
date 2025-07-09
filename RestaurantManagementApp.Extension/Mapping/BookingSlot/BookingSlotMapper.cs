namespace RestaurantManagementApp.Extension.Mapping.BookingSlot;

public static class BookingSlotMapper
{
    public static TblBookingSlot ToEntity(this BookingSlotDto bookingSlotDto)
    {
        return new TblBookingSlot
        {
            Id = bookingSlotDto.Id,
            SlotNumber = bookingSlotDto.SlotNumber,
            StartTime = bookingSlotDto.StartTime,
            EndTime = bookingSlotDto.EndTime,
            IsAvailable = bookingSlotDto.IsAvailable.Name
        };
    }

    public static BookingSlotDto ToDto(this TblBookingSlot dataModel)
    {
        return new BookingSlotDto
        {
            Id = dataModel.Id,
            SlotNumber = dataModel.SlotNumber,
            BookingDate = dataModel.BookingDate,
            StartTime = dataModel.StartTime,
            EndTime = dataModel.EndTime,
            IsAvailable = BookingSlotStatus.FromName(dataModel.IsAvailable, ignoreCase: true)
        };
    }

    public static TblBookingSlot ToEntity(this CreateBookingSlotDto createBookingSlot)
    {
        return new TblBookingSlot
        {
            SlotNumber = createBookingSlot.SlotNumber,
            BookingDate = Converter.ToDate(createBookingSlot.BookingDate),
            StartTime = Converter.ToTime(createBookingSlot.StartTime),
            EndTime = Converter.ToTime(createBookingSlot.EndTime),
            IsAvailable = BookingSlotStatus.Pending.Name
        };
    }

    public static TblBookingSlot ToEntity(this UpdateBookingSlotDto updateBookingSlot, TblBookingSlot tblBookingSlot)
    {
        tblBookingSlot.BookingDate = updateBookingSlot.BookingDate;
        tblBookingSlot.StartTime = updateBookingSlot.StartTime;
        tblBookingSlot.EndTime = updateBookingSlot.EndTime;
        tblBookingSlot.IsAvailable = updateBookingSlot.IsAvailable.Name;

        return tblBookingSlot;
    }
}