using FSH.WebApi.Application.HMS.Charges;

namespace FSH.WebApi.Host.Controllers.HMS;

public class ChargesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Charges)]
    [OpenApiOperation("Search charges using available filters.", "")]
    public Task<PaginationResponse<ChargeDto>> SearchAsync(SearchChargesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Charges)]
    [OpenApiOperation("Get charge details.", "")]
    public Task<ChargeDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetChargeRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Charges)]
    [OpenApiOperation("Get charge details via dapper.", "")]
    public Task<ChargeDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetChargeViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Charges)]
    [OpenApiOperation("Create a new charge.", "")]
    public Task<Guid> CreateAsync(CreateChargeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Charges)]
    [OpenApiOperation("Update a charge.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateChargeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Charges)]
    [OpenApiOperation("Delete a charge.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteChargeRequest(id));
    }
}