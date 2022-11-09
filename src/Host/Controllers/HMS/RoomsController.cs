using FSH.WebApi.Application.HMS.Rooms;

namespace FSH.WebApi.Host.Controllers.HMS;

public class RoomsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Rooms)]
    [OpenApiOperation("Search rooms using available filters.", "")]
    public Task<PaginationResponse<RoomDto>> SearchAsync(SearchRoomsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Rooms)]
    [OpenApiOperation("Get room details.", "")]
    public Task<RoomDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetRoomRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Rooms)]
    [OpenApiOperation("Get room details via dapper.", "")]
    public Task<RoomDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetRoomViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Rooms)]
    [OpenApiOperation("Create a new room.", "")]
    public Task<Guid> CreateAsync(CreateRoomRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Rooms)]
    [OpenApiOperation("Update a room.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateRoomRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Rooms)]
    [OpenApiOperation("Delete a room.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteRoomRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.Rooms)]
    [OpenApiOperation("Export a rooms.", "")]
    public async Task<FileResult> ExportAsync(ExportRoomsRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "RoomExports");
    }
    }