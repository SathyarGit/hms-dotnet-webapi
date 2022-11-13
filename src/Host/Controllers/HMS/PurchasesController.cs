using FSH.WebApi.Application.HMS.Purchases;

namespace FSH.WebApi.Host.Controllers.HMS;

public class PurchasesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Purchases)]
    [OpenApiOperation("Search purchases using available filters.", "")]
    public Task<PaginationResponse<PurchaseDto>> SearchAsync(SearchPurchasesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Purchases)]
    [OpenApiOperation("Get purchase details.", "")]
    public Task<PurchaseDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPurchaseRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Purchases)]
    [OpenApiOperation("Get purchase details via dapper.", "")]
    public Task<PurchaseDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetPurchaseViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Purchases)]
    [OpenApiOperation("Create a new purchase.", "")]
    public Task<Guid> CreateAsync(CreatePurchaseRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Purchases)]
    [OpenApiOperation("Update a purchase.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePurchaseRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Purchases)]
    [OpenApiOperation("Delete a purchase.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePurchaseRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.Purchases)]
    [OpenApiOperation("Export a purchases.", "")]
    public async Task<FileResult> ExportAsync(ExportPurchasesRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "PurchaseExports");
    }
    }