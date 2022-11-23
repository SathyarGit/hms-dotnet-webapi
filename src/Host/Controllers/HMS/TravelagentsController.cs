using FSH.WebApi.Application.HMS.Rooms;
using FSH.WebApi.Application.HMS.Travelagents;

namespace FSH.WebApi.Host.Controllers.HMS;

public class TravelagentsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Travelagents)]
    [OpenApiOperation("Search travelagents using available filters.", "")]
    public Task<PaginationResponse<TravelagentDto>> SearchAsync(SearchTravelagentsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Travelagents)]
    [OpenApiOperation("Get travelagent details.", "")]
    public Task<TravelagentDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetTravelagentRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Travelagents)]
    [OpenApiOperation("Get travelagent details via dapper.", "")]
    public Task<TravelagentDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetTravelagentViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Travelagents)]
    [OpenApiOperation("Create a new travelagent.", "")]
    public Task<Guid> CreateAsync(CreateTravelagentRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Travelagents)]
    [OpenApiOperation("Update a travelagent.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTravelagentRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Travelagents)]
    [OpenApiOperation("Delete a travelagent.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteTravelagentRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.Travelagents)]
    [OpenApiOperation("Export a travelagent.", "")]
    public async Task<FileResult> ExportAsync(ExportTravelagentsRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "TravelagentExports");
    }
}