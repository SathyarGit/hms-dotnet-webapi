namespace FSH.WebApi.Domain.HMS;

public class Employee : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public string? Address { get; private set; }
    public string? Notes { get; private set; }
    public string? ImagePath { get; private set; }
    public DefaultIdType DepartmentId { get; private set; }
    public virtual Department Department { get; private set; } = default!;

    public Employee()
    {
        // Only needed for working with dapper (See GetEmployeeViaDapperRequest)
        // If you're not using dapper it's better to remove this constructor.
    }

    public Employee(string name, string? address, string? notes, DefaultIdType departmentId, string? imagePath)
    {
        Name = name;
        Address = address;
        Notes = notes;
        DepartmentId = departmentId;
        ImagePath = imagePath;
    }

    public Employee Update(string? name, string? address, string? notes, DefaultIdType? departmentId, string? imagePath)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (notes is not null && Notes?.Equals(notes) is not true) Notes = notes;
        if (departmentId.HasValue && departmentId.Value != DefaultIdType.Empty && !DepartmentId.Equals(departmentId.Value)) DepartmentId = departmentId.Value;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        return this;
    }

    public Employee ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }
}