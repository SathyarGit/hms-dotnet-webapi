namespace FSH.WebApi.Domain.HMS;

public class Foliotype : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public virtual ICollection<Folio> Folios { get; set; }

    public Foliotype(string name, string? description)
    {
        Name = name;
        Description = description;
        Folios = new HashSet<Folio>();
    }

    public Foliotype Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}