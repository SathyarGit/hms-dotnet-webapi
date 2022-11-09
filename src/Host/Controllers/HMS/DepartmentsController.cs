using FSH.WebApi.Application.HMS.Departments;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class DepartmentsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Departments)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<DepartmentDto>> SearchAsync(SearchDepartmentsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Departments)]
    [OpenApiOperation("Get product details.", "")]
    public Task<DepartmentDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetDepartmentRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Departments)]
    [OpenApiOperation("Get product details via dapper.", "")]
    public Task<DepartmentDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetDepartmentViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Departments)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateDepartmentRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Departments)]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateDepartmentRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Departments)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteDepartmentRequest(id));
    }
}