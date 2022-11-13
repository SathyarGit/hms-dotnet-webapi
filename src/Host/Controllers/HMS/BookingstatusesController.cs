using FSH.WebApi.Application.HMS.Bookingstatuses;

namespace FSH.WebApi.Host.Controllers.HMS;

public class BookingstatusesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Bookingstatuses)]
    [OpenApiOperation("Search bookingstatuses using available filters.", "")]
    public Task<PaginationResponse<BookingstatusDto>> SearchAsync(SearchBookingstatusesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Bookingstatuses)]
    [OpenApiOperation("Get bookingstatus details.", "")]
    public Task<BookingstatusDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetBookingstatusRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Bookingstatuses)]
    [OpenApiOperation("Get bookingstatus details via dapper.", "")]
    public Task<BookingstatusDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetBookingstatusViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Bookingstatuses)]
    [OpenApiOperation("Create a new bookingstatus.", "")]
    public Task<Guid> CreateAsync(CreateBookingstatusRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Bookingstatuses)]
    [OpenApiOperation("Update a bookingstatus.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateBookingstatusRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Bookingstatuses)]
    [OpenApiOperation("Delete a bookingstatus.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteBookingstatusRequest(id));
    }
}