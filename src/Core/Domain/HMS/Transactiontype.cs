namespace FSH.WebApi.Domain.HMS;

public class Transactiontype : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public virtual ICollection<Accountentry> Accountentries { get; set; }

    public Transactiontype(string name, string? description)
    {
        Name = name;
        Description = description;
        Accountentries = new HashSet<Accountentry>();
    }

    public Transactiontype Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}