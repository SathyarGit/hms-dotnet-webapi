using FSH.WebApi.Application.HMS.Roomsbookeds;

namespace FSH.WebApi.Host.Controllers.HMS;

public class RoomsbookedsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Roomsbookeds)]
    [OpenApiOperation("Search roomsbookeds using available filters.", "")]
    public Task<PaginationResponse<RoomsbookedDto>> SearchAsync(SearchRoomsbookedsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Roomsbookeds)]
    [OpenApiOperation("Get roomsbooked details.", "")]
    public Task<RoomsbookedDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetRoomsbookedRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Roomsbookeds)]
    [OpenApiOperation("Get roomsbooked details via dapper.", "")]
    public Task<RoomsbookedDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetRoomsbookedViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Roomsbookeds)]
    [OpenApiOperation("Create a new roomsbooked.", "")]
    public Task<Guid> CreateAsync(CreateRoomsbookedRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Roomsbookeds)]
    [OpenApiOperation("Update a roomsbooked.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateRoomsbookedRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Roomsbookeds)]
    [OpenApiOperation("Delete a roomsbooked.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteRoomsbookedRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.Roomsbookeds)]
    [OpenApiOperation("Export a roomsbookeds.", "")]
    public async Task<FileResult> ExportAsync(ExportRoomsbookedsRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "RoomsbookedExports");
    }
    }