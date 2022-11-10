namespace FSH.WebApi.Domain.HMS;

public class Customerclassification : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public Customerclassification(string name, string? description)
    {
        Name = name;
        Description = description;
        Customers = new HashSet<Customer>();
    }

    public Customerclassification Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }

    public virtual ICollection<Customer> Customers { get; set; }

}