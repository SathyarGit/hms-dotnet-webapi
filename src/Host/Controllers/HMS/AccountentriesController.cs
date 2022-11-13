using FSH.WebApi.Application.HMS.Accountentries;

namespace FSH.WebApi.Host.Controllers.HMS;

public class AccountentriesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Accountentries)]
    [OpenApiOperation("Search accountentries using available filters.", "")]
    public Task<PaginationResponse<AccountentryDto>> SearchAsync(SearchAccountentriesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Accountentries)]
    [OpenApiOperation("Get accountentry details.", "")]
    public Task<AccountentryDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAccountentryRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Accountentries)]
    [OpenApiOperation("Get accountentry details via dapper.", "")]
    public Task<AccountentryDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetAccountentryViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Accountentries)]
    [OpenApiOperation("Create a new accountentry.", "")]
    public Task<Guid> CreateAsync(CreateAccountentryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Accountentries)]
    [OpenApiOperation("Update a accountentry.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAccountentryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Accountentries)]
    [OpenApiOperation("Delete a accountentry.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteAccountentryRequest(id));
    }
}