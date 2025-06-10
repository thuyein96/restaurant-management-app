using RestaurantManagementApp.Dtos.Features.Reservation;
using RestaurantManagementApp.Modules.Features.Reservation;

namespace RestaurantManagementApp.Api.Controllers.Reservation;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : BaseController
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var result = await _reservationService.GetReservationsAsync();
        return Content(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationById(Guid id)
    {
        var result = await _reservationService.GetReservationByIdAsync(id);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation(
        [FromBody] CreateReservationDto createReservationDto
    )
    {
        var result = await _reservationService.CreateReservationAsync(createReservationDto);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(
        Guid id,
        [FromBody] UpdateReservationDto updateReservationDto
    )
    {
        var result = await _reservationService.UpdateReservationAsync(id, updateReservationDto);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(Guid id)
    {
        var result = await _reservationService.DeleteReservationAsync(id);
        return Content(result);
    }

    // Additional endpoints specific to reservations
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetReservationsByCustomer(Guid customerId)
    {
        var result = await _reservationService.GetReservationsByCustomerAsync(customerId);
        return Content(result);
    }

    [HttpPut("{id}/confirm")]
    public async Task<IActionResult> ConfirmReservation(Guid id)
    {
        var result = await _reservationService.ConfirmReservationAsync(id);
        return Content(result);
    }

    [HttpGet("date/{date}")]
    public async Task<IActionResult> GetReservationsByDate(DateOnly date)
    {
        var result = await _reservationService.GetReservationsByDateAsync(date);
        return Content(result);
    }
}