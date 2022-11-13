using FSH.WebApi.Application.HMS.Employees;

namespace FSH.WebApi.Host.Controllers.HMS;

public class EmployeesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Employees)]
    [OpenApiOperation("Search employees using available filters.", "")]
    public Task<PaginationResponse<EmployeeDto>> SearchAsync(SearchEmployeesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Employees)]
    [OpenApiOperation("Get employee details.", "")]
    public Task<EmployeeDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetEmployeeRequest(id));
    }

    [HttpGet("dapper")]
    [MustHavePermission(FSHAction.View, FSHResource.Employees)]
    [OpenApiOperation("Get employee details via dapper.", "")]
    public Task<EmployeeDto> GetDapperAsync(Guid id)
    {
        return Mediator.Send(new GetEmployeeViaDapperRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Employees)]
    [OpenApiOperation("Create a new employee.", "")]
    public Task<Guid> CreateAsync(CreateEmployeeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Employees)]
    [OpenApiOperation("Update a employee.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateEmployeeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Employees)]
    [OpenApiOperation("Delete a employee.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteEmployeeRequest(id));
    }

    [HttpPost("export")]
    [MustHavePermission(FSHAction.Export, FSHResource.Employees)]
    [OpenApiOperation("Export a employees.", "")]
    public async Task<FileResult> ExportAsync(ExportEmployeesRequest filter)
    {
        var result = await Mediator.Send(filter);
        return File(result, "application/octet-stream", "EmployeeExports");
    }
    }