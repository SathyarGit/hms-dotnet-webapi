using Mapster;

namespace FSH.WebApi.Application.HMS.Employees;

public class GetEmployeeViaDapperRequest : IRequest<EmployeeDto>
{
    public DefaultIdType Id { get; set; }

    public GetEmployeeViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetEmployeeViaDapperRequestHandler : IRequestHandler<GetEmployeeViaDapperRequest, EmployeeDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetEmployeeViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetEmployeeViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<EmployeeDto> Handle(GetEmployeeViaDapperRequest request, CancellationToken cancellationToken)
    {
        var employee = await _repository.QueryFirstOrDefaultAsync<Employee>(
            $"SELECT * FROM HMS.\"Employees\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = employee ?? throw new NotFoundException(_t["Employee {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "DepartmentName" property
        // in EmployeeDto and the employee not having a Department assigned.
        return new EmployeeDto
        {
            Id = employee.Id,
            DepartmentId = employee.DepartmentId,
            DepartmentName = string.Empty,
            Notes = employee.Notes,
            ImagePath = employee.ImagePath,
            Name = employee.Name
        };
    }
}