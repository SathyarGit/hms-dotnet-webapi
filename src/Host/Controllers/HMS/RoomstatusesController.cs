using FSH.WebApi.Application.HMS.Roomstatuses;

namespace FSH.WebApi.Host.Controllers.HMS;

public class RoomstatusesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Roomstatuses)]
    [OpenApiOperation("Search roomstatustypes using available filters.", "")]
    public Task<PaginationResponse<RoomstatusDto>> SearchAsync(SearchRoomstatusesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Roomstatuses)]
    [OpenApiOperation("Get roomstatus details.", "")]
    public Task<RoomstatusDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetRoomstatusRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Roomstatuses)]
    [OpenApiOperation("Get roomstatus details via dapper.", "")]
    public Task<RoomstatusDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetRoomstatusViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Roomstatuses)]
    [OpenApiOperation("Create a new roomstatus.", "")]
    public Task<Guid> CreateAsync(CreateRoomstatusRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Roomstatuses)]
    [OpenApiOperation("Update a roomstatus.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateRoomstatusRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Roomstatuses)]
    [OpenApiOperation("Delete a roomstatus.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteRoomstatusRequest(id));
    }
    }