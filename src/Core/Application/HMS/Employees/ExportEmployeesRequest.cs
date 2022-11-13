using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Employees;

public class ExportEmployeesRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? DepartmentId { get; set; }
}

public class ExportEmployeesRequestHandler : IRequestHandler<ExportEmployeesRequest, Stream>
{
    private readonly IReadRepository<Employee> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportEmployeesRequestHandler(IReadRepository<Employee> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportEmployeesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportEmployeesWithDepartmentsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportEmployeesWithDepartmentsSpecification : EntitiesByBaseFilterSpec<Employee, EmployeeExportDto>
{
    public ExportEmployeesWithDepartmentsSpecification(ExportEmployeesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Department)
            .Where(p => p.DepartmentId.Equals(request.DepartmentId!.Value), request.DepartmentId.HasValue);
}