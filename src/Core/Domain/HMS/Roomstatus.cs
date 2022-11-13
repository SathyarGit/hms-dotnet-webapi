namespace FSH.WebApi.Domain.HMS;

public class Roomstatus : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

    public Roomstatus(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public Roomstatus Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}