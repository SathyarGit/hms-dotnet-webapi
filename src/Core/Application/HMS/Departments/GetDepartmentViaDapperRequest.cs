using Mapster;

namespace FSH.WebApi.Application.HMS.Departments;

public class GetDepartmentViaDapperRequest : IRequest<DepartmentDto>
{
    public Guid Id { get; set; }

    public GetDepartmentViaDapperRequest(Guid id) => Id = id;
}

public class GetDepartmentViaDapperRequestHandler : IRequestHandler<GetDepartmentViaDapperRequest, DepartmentDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetDepartmentViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetDepartmentViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DepartmentDto> Handle(GetDepartmentViaDapperRequest request, CancellationToken cancellationToken)
    {
        var department = await _repository.QueryFirstOrDefaultAsync<Department>(
            $"SELECT * FROM HMS.\"Departments\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = department ?? throw new NotFoundException(_t["Department {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in DepartmentDto and the department not having a Brand assigned.
        return new DepartmentDto
        {
            Id = department.Id,
            Description = department.Description,
            Name = department.Name
        };
    }
}