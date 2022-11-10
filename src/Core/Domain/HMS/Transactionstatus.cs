using System;
using System.Runtime.InteropServices;

namespace FSH.WebApi.Domain.HMS;

public class Transactionstatus : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public virtual ICollection<Charge> Charges { get; set; }
    public virtual ICollection<Purchase> Purchases { get; set; }

    public Transactionstatus(string name, string? description)
    {
        Name = name;
        Description = description;

        Charges = new HashSet<Charge>();
        Purchases = new HashSet<Purchase>();
    }

    public Transactionstatus Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}