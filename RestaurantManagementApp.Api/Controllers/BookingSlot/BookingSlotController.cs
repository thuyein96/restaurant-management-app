namespace RestaurantManagementApp.Api.Controllers.BookingSlot;

[Route("api/[controller]")]
[ApiController]
public class BookingSlotController : BaseController
{
    private readonly IBookingSlotService _bookingSlotService;

    public BookingSlotController(IBookingSlotService bookingSlotService)
    {
        _bookingSlotService = bookingSlotService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookingSlots()
    {
        var result = await _bookingSlotService.GetBookingSlotsAsync();
        return Content(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingSlotById(Guid id)
    {
        var result = await _bookingSlotService.GetBookingSlotByIdAsync(id);
        return Content(result);
    }

    [HttpGet("slot-number/{slotNumber}")]
    public async Task<IActionResult> GetBookingSlotBySlotNumber(string slotNumber)
    {
        var result = await _bookingSlotService.GetBookingSlotBySlotNumberAsync(slotNumber);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookingSlot(
        [FromBody] CreateBookingSlotDto createBookingSlot
    )
    {
        var result = await _bookingSlotService.CreateBookingSlotAsync(createBookingSlot);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookingSlot(
        Guid id,
        [FromBody] UpdateBookingSlotDto updateBookingSlotDto
    )
    {
        var result = await _bookingSlotService.UpdateBookingSlotAsync(id, updateBookingSlotDto);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookingSlot(Guid id)
    {
        var result = await _bookingSlotService.DeleteBookingSlotAsync(id);
        return Content(result);
    }
}