using FSH.WebApi.Application.HMS.Floors;

namespace FSH.WebApi.Host.Controllers.HMS;

public class FloorsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Floors)]
    [OpenApiOperation("Search floors using available filters.", "")]
    public Task<PaginationResponse<FloorDto>> SearchAsync(SearchFloorsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Floors)]
    [OpenApiOperation("Get floor details.", "")]
    public Task<FloorDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetFloorRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Floors)]
    [OpenApiOperation("Get floor details via dapper.", "")]
    public Task<FloorDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetFloorViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Floors)]
    [OpenApiOperation("Create a new floor.", "")]
    public Task<Guid> CreateAsync(CreateFloorRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Floors)]
    [OpenApiOperation("Update a floor.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateFloorRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Floors)]
    [OpenApiOperation("Delete a floor.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteFloorRequest(id));
    }
}