namespace FSH.WebApi.Application.HMS.Employees;

public class UpdateEmployeeRequestValidator : CustomValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeRequestValidator(IReadRepository<Employee> employeeRepo, IReadRepository<Department> departmentRepo, IStringLocalizer<UpdateEmployeeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (employee, name, ct) =>
                    await employeeRepo.GetBySpecAsync(new EmployeeByNameSpec(name), ct)
                        is not Employee existingEmployee || existingEmployee.Id == employee.Id)
                .WithMessage((_, name) => T["Employee {0} already Exists.", name]);

        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.DepartmentId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await departmentRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Department {0} Not Found.", id]);
    }
}