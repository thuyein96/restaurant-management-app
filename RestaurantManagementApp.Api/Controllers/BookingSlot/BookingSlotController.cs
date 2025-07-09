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
    
    [SwaggerOperation(Summary = "Get all booking slots")]
    [HttpGet]
    public async Task<IActionResult> GetBookingSlots()
    {
        var result = await _bookingSlotService.GetBookingSlotsAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get booking slot by id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingSlotById(Guid id)
    {
        var result = await _bookingSlotService.GetBookingSlotByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get booking slot by slot number")]
    [HttpGet("slot-number/{slotNumber}")]
    public async Task<IActionResult> GetBookingSlotBySlotNumber(string slotNumber)
    {
        var result = await _bookingSlotService.GetBookingSlotBySlotNumberAsync(slotNumber);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Create a booking slot")]
    [HttpPost]
    public async Task<IActionResult> CreateBookingSlot(
        [FromBody] CreateBookingSlotDto createBookingSlot
    )
    {
        var result = await _bookingSlotService.CreateBookingSlotAsync(createBookingSlot);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Update an existing booking slot")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookingSlot(
        Guid id,
        [FromBody] UpdateBookingSlotDto updateBookingSlotDto
    )
    {
        var result = await _bookingSlotService.UpdateBookingSlotAsync(id, updateBookingSlotDto);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Delete a booking slot")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookingSlot(Guid id)
    {
        var result = await _bookingSlotService.DeleteBookingSlotAsync(id);
        return Content(result);
    }
}