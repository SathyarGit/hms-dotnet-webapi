using FSH.WebApi.Application.HMS.Transactionstatuses;

namespace FSH.WebApi.Host.Controllers.HMS;

public class TransactionstatusesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Transactionstatuses)]
    [OpenApiOperation("Search transactionstatuss using available filters.", "")]
    public Task<PaginationResponse<TransactionstatusDto>> SearchAsync(SearchTransactionstatusesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Transactionstatuses)]
    [OpenApiOperation("Get transactionstatus details.", "")]
    public Task<TransactionstatusDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetTransactionstatusRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Transactionstatuses)]
    [OpenApiOperation("Get transactionstatus details via dapper.", "")]
    public Task<TransactionstatusDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetTransactionstatusViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Transactionstatuses)]
    [OpenApiOperation("Create a new transactionstatus.", "")]
    public Task<Guid> CreateAsync(CreateTransactionstatusRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Transactionstatuses)]
    [OpenApiOperation("Update a transactionstatus.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTransactionstatusRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Transactionstatuses)]
    [OpenApiOperation("Delete a transactionstatus.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteTransactionstatusRequest(id));
    }
}