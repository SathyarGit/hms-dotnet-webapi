using FSH.WebApi.Application.HMS.Folios;

namespace FSH.WebApi.Host.Controllers.HMS;

public class FoliosController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Folios)]
    [OpenApiOperation("Search folios using available filters.", "")]
    public Task<PaginationResponse<FolioDto>> SearchAsync(SearchFoliosRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Folios)]
    [OpenApiOperation("Get folio details.", "")]
    public Task<FolioDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetFolioRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Folios)]
    [OpenApiOperation("Get folio details via dapper.", "")]
    public Task<FolioDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetFolioViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Folios)]
    [OpenApiOperation("Create a new folio.", "")]
    public Task<Guid> CreateAsync(CreateFolioRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Folios)]
    [OpenApiOperation("Update a folio.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateFolioRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Folios)]
    [OpenApiOperation("Delete a folio.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteFolioRequest(id));
    }
}