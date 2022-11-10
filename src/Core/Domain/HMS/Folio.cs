namespace FSH.WebApi.Domain.HMS;

public class Folio : AuditableEntity, IAggregateRoot
{
    public DefaultIdType? BookingId { get; set; }
    public DefaultIdType? FoliotypeId { get; set; }
    public string? Description { get; set; }

    public virtual Foliotype Foliotype { get; set; } = default!;
    public virtual Booking Booking { get; set; } = default!;
    public virtual ICollection<Accountentry> Accountentries { get; set; }
    public virtual ICollection<Charge> Charges { get; set; }

    public Folio(DefaultIdType? bookingId, DefaultIdType? foliotypeId, string? description)
    {
        BookingId = bookingId;
        FoliotypeId = foliotypeId;
        Description = description;

        Charges = new HashSet<Charge>();
        Accountentries = new HashSet<Accountentry>();
    }

    public Folio Update(DefaultIdType? bookingId, DefaultIdType? foliotypeId, string? description)
    {
        if (bookingId.HasValue && bookingId.Value != DefaultIdType.Empty && !BookingId.Equals(bookingId.Value)) BookingId = bookingId.Value;
        if (foliotypeId.HasValue && foliotypeId.Value != DefaultIdType.Empty && !FoliotypeId.Equals(foliotypeId.Value)) FoliotypeId = foliotypeId.Value;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}