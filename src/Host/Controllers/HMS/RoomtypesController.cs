using FSH.WebApi.Application.HMS.Roomtypes;

namespace FSH.WebApi.Host.Controllers.HMS;

public class RoomtypesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Roomtypes)]
    [OpenApiOperation("Search roomtypetypes using available filters.", "")]
    public Task<PaginationResponse<RoomtypeDto>> SearchAsync(SearchRoomtypesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Roomtypes)]
    [OpenApiOperation("Get roomtype details.", "")]
    public Task<RoomtypeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetRoomtypeRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Roomtypes)]
    [OpenApiOperation("Get roomtype details via dapper.", "")]
    public Task<RoomtypeDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetRoomtypeViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Roomtypes)]
    [OpenApiOperation("Create a new roomtype.", "")]
    public Task<Guid> CreateAsync(CreateRoomtypeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Roomtypes)]
    [OpenApiOperation("Update a roomtype.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateRoomtypeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Roomtypes)]
    [OpenApiOperation("Delete a roomtype.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteRoomtypeRequest(id));
    }
    }