using FSH.WebApi.Application.HMS.Bookings;

namespace FSH.WebApi.Host.Controllers.HMS;

public class BookingsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Bookings)]
    [OpenApiOperation("Search bookings using available filters.", "")]
    public Task<PaginationResponse<BookingDto>> SearchAsync(SearchBookingsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Bookings)]
    [OpenApiOperation("Get booking details.", "")]
    public Task<BookingDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetBookingRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Bookings)]
    [OpenApiOperation("Get booking details via dapper.", "")]
    public Task<BookingDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetBookingViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Bookings)]
    [OpenApiOperation("Create a new booking.", "")]
    public Task<Guid> CreateAsync(CreateBookingRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Bookings)]
    [OpenApiOperation("Update a booking.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateBookingRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Bookings)]
    [OpenApiOperation("Delete a booking.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteBookingRequest(id));
    }
}