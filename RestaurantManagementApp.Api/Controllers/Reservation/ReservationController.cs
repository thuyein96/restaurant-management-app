namespace RestaurantManagementApp.Api.Controllers.Reservation;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : BaseController
{
    private readonly IReservationService _reservationService;
    private readonly IEmailService _emailService;

    public ReservationController(IReservationService reservationService,
        IEmailService emailService)
    {
        _reservationService = reservationService;
        _emailService = emailService;
    }
    
    [SwaggerOperation(Summary = "Get all reservations")]
    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var result = await _reservationService.GetReservationsAsync();
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Get reservation by id")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationById(Guid id)
    {
        var result = await _reservationService.GetReservationByIdAsync(id);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Create a reservation")]
    [HttpPost]
    public async Task<IActionResult> CreateReservation(
        [FromBody] CreateReservationDto createReservationDto
    )
    {
        var result = await _reservationService.CreateReservationAsync(createReservationDto);
        var email = await _emailService.SendEmailAsync(createReservationDto.Email,
            "Reservation Confirmation",
            "<html><head></head><body><p>Hello,</p>This is my first transactional email sent from Brevo.</p></body></html>");
        
        return Ok(email);
    }
    
    [SwaggerOperation(Summary = "Update an existing reservation")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(
        Guid id,
        [FromBody] UpdateReservationDto updateReservationDto
    )
    {
        var result = await _reservationService.UpdateReservationAsync(id, updateReservationDto);
        return Content(result);
    }
    
    [SwaggerOperation(Summary = "Delete a reservation")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(Guid id)
    {
        var result = await _reservationService.DeleteReservationAsync(id);
        return Content(result);
    }

    [SwaggerOperation(Summary = "Search reservations by reservation number or date")]
    [HttpGet("search")]
    public async Task<IActionResult> GetReservationsByCustomer([FromQuery] string? reservationNumber, 
                                                                [FromQuery] DateOnly? date)
    {
        if (string.IsNullOrWhiteSpace(reservationNumber) || date == null)
        {
            return BadRequest("Need reservation number or date");
        }
        var result = await _reservationService.GetReservationsWithQueryValuesAsync(reservationNumber, date);
        return Content(result);
    }
}