namespace FSH.WebApi.Domain.HMS;

public class Vendor : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? Notes { get; private set; }

    public Vendor(string name, string? description, string? notes)
    {
        Name = name;
        Description = description;
        Notes = notes;
    }

    public Vendor Update(string? name, string? description, string? notes)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (notes is not null && Notes?.Equals(notes) is not true) Notes = notes;
        return this;
    }
}