using FSH.WebApi.Application.HMS.Transactiontypes;

namespace FSH.WebApi.Host.Controllers.HMS;

public class TransactiontypesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Transactiontypes)]
    [OpenApiOperation("Search travelagents using available filters.", "")]
    public Task<PaginationResponse<TransactiontypeDto>> SearchAsync(SearchTransactiontypesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Transactiontypes)]
    [OpenApiOperation("Get travelagent details.", "")]
    public Task<TransactiontypeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetTransactiontypeRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Transactiontypes)]
    [OpenApiOperation("Get travelagent details via dapper.", "")]
    public Task<TransactiontypeDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetTransactiontypeViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Transactiontypes)]
    [OpenApiOperation("Create a new travelagent.", "")]
    public Task<Guid> CreateAsync(CreateTransactiontypeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Transactiontypes)]
    [OpenApiOperation("Update a travelagent.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTransactiontypeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Transactiontypes)]
    [OpenApiOperation("Delete a travelagent.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteTransactiontypeRequest(id));
    }
}