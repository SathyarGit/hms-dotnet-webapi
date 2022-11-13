using FSH.WebApi.Application.HMS.Vendors;

namespace FSH.WebApi.Host.Controllers.HMS;

public class VendorsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Vendors)]
    [OpenApiOperation("Search vendors using available filters.", "")]
    public Task<PaginationResponse<VendorDto>> SearchAsync(SearchVendorsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Vendors)]
    [OpenApiOperation("Get vendor details.", "")]
    public Task<VendorDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetVendorRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Vendors)]
    [OpenApiOperation("Get vendor details via dapper.", "")]
    public Task<VendorDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetVendorViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Vendors)]
    [OpenApiOperation("Create a new vendor.", "")]
    public Task<Guid> CreateAsync(CreateVendorRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Vendors)]
    [OpenApiOperation("Update a vendor.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateVendorRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Vendors)]
    [OpenApiOperation("Delete a vendor.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteVendorRequest(id));
    }
}