using FSH.WebApi.Application.HMS.Expensecategories;

namespace FSH.WebApi.Host.Controllers.HMS;

public class ExpensecategoriesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Expensecategories)]
    [OpenApiOperation("Search expensecategories using available filters.", "")]
    public Task<PaginationResponse<ExpensecategoryDto>> SearchAsync(SearchExpensecategoriesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Expensecategories)]
    [OpenApiOperation("Get expensecategory details.", "")]
    public Task<ExpensecategoryDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetExpensecategoryRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Expensecategories)]
    [OpenApiOperation("Get expensecategory details via dapper.", "")]
    public Task<ExpensecategoryDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetExpensecategoryViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Expensecategories)]
    [OpenApiOperation("Create a new expensecategory.", "")]
    public Task<Guid> CreateAsync(CreateExpensecategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Expensecategories)]
    [OpenApiOperation("Update a expensecategory.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateExpensecategoryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Expensecategories)]
    [OpenApiOperation("Delete a expensecategory.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteExpensecategoryRequest(id));
    }
}