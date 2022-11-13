using FSH.WebApi.Application.HMS.Foliotypes;

namespace FSH.WebApi.Host.Controllers.HMS;

public class FoliotypesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Foliotypes)]
    [OpenApiOperation("Search foliotypetypes using available filters.", "")]
    public Task<PaginationResponse<FoliotypeDto>> SearchAsync(SearchFoliotypesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Foliotypes)]
    [OpenApiOperation("Get foliotype details.", "")]
    public Task<FoliotypeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetFoliotypeRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Foliotypes)]
    [OpenApiOperation("Get foliotype details via dapper.", "")]
    public Task<FoliotypeDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetFoliotypeViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Foliotypes)]
    [OpenApiOperation("Create a new foliotype.", "")]
    public Task<Guid> CreateAsync(CreateFoliotypeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Foliotypes)]
    [OpenApiOperation("Update a foliotype.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateFoliotypeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Foliotypes)]
    [OpenApiOperation("Delete a foliotype.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteFoliotypeRequest(id));
    }
    }