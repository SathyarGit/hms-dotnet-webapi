using FSH.WebApi.Application.HMS.Customerclassifications;

namespace FSH.WebApi.Host.Controllers.HMS;

public class CustomerclassificationsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Customerclassifications)]
    [OpenApiOperation("Search customerclassifications using available filters.", "")]
    public Task<PaginationResponse<CustomerclassificationDto>> SearchAsync(SearchCustomerclassificationsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Customerclassifications)]
    [OpenApiOperation("Get customerclassification details.", "")]
    public Task<CustomerclassificationDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCustomerclassificationRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Customerclassifications)]
    [OpenApiOperation("Get customerclassification details via dapper.", "")]
    public Task<CustomerclassificationDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetCustomerclassificationViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Customerclassifications)]
    [OpenApiOperation("Create a new customerclassification.", "")]
    public Task<Guid> CreateAsync(CreateCustomerclassificationRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Customerclassifications)]
    [OpenApiOperation("Update a customerclassification.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCustomerclassificationRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Customerclassifications)]
    [OpenApiOperation("Delete a customerclassification.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCustomerclassificationRequest(id));
    }
}