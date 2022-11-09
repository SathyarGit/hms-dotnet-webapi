namespace FSH.WebApi.Application.HMS.Employees;

public class CreateEmployeeRequestValidator : CustomValidator<CreateEmployeeRequest>
{
    public CreateEmployeeRequestValidator(IReadRepository<Employee> employeeRepo, IReadRepository<Department> departmentRepo, IStringLocalizer<CreateEmployeeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75);

        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.DepartmentId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await departmentRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Department {0} Not Found.", id]);
    }
}