using FSH.WebApi.Application.HMS.Paymentmodes;

namespace FSH.WebApi.Host.Controllers.HMS;

public class PaymentmodesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Paymentmodes)]
    [OpenApiOperation("Search paymentmodes using available filters.", "")]
    public Task<PaginationResponse<PaymentmodeDto>> SearchAsync(SearchPaymentmodesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Paymentmodes)]
    [OpenApiOperation("Get paymentmode details.", "")]
    public Task<PaymentmodeDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPaymentmodeRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Paymentmodes)]
    [OpenApiOperation("Get paymentmode details via dapper.", "")]
    public Task<PaymentmodeDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetPaymentmodeViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Paymentmodes)]
    [OpenApiOperation("Create a new paymentmode.", "")]
    public Task<Guid> CreateAsync(CreatePaymentmodeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Paymentmodes)]
    [OpenApiOperation("Update a paymentmode.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePaymentmodeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Paymentmodes)]
    [OpenApiOperation("Delete a paymentmode.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePaymentmodeRequest(id));
    }
    }