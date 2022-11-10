
namespace FSH.WebApi.Domain.HMS;

public class Booking : AuditableEntity, IAggregateRoot
{
    public DateTime? CheckinDate { get; private set; }
    public DateTime? CheckoutDate { get; private set; }
    public int? NumberOfRooms { get; private set; }
    public int? NumberOfAdults { get; private set; }
    public int? NumberOfChildren { get; private set; }
    public DefaultIdType? BookingstatusId { get; private set; }
    public int? Amount { get; private set; }
    public string? Notes { get; private set; }
    public bool? BookingMaterialised { get; private set; }
    public DefaultIdType? CustomerId { get; private set; }
    public DefaultIdType? TravelagentId { get; private set; }
    public DefaultIdType? FolioId { get; private set; }

    public virtual Bookingstatus Bookingstatus { get; set; } = default!;
    public virtual Customer Customer { get; set; } = default!;
    public virtual Travelagent Travelagent { get; set; } = default!;
    public virtual Folio Folio { get; set; } = default!;

    public virtual ICollection<Roomsbooked> Roomsbookeds { get; set; } = default!;


    public Booking(DateTime? checkinDate, DateTime? checkoutDate, int? numberOfRooms, int? numberOfAdults,
                    int? numberOfChildren, DefaultIdType? bookingstatusId, int? amount, string? notes,
                    bool? bookingMaterialised, DefaultIdType? customerId, DefaultIdType? travelagentId, DefaultIdType? folioId)
    {
        CheckinDate = checkinDate;
        CheckoutDate = checkoutDate;
        NumberOfRooms = numberOfRooms;
        NumberOfAdults = numberOfAdults;
        NumberOfChildren = numberOfChildren;
        BookingstatusId = bookingstatusId;
        Amount = amount;
        Notes = notes;
        BookingMaterialised = bookingMaterialised;
        CustomerId = customerId;
        TravelagentId = travelagentId;
        FolioId = folioId;
    }

    public Booking Update(DateTime? checkinDate, DateTime? checkoutDate, int? numberOfRooms, int? numberOfAdults,
                    int? numberOfChildren, DefaultIdType? bookingstatusId, int? amount, string? notes,
                    bool? bookingMaterialised, DefaultIdType? customerId, DefaultIdType? travelagentId, DefaultIdType? folioId)
    {
        if (checkinDate.HasValue && CheckinDate != checkinDate) CheckinDate = checkinDate.Value;
        if (checkoutDate.HasValue && CheckoutDate != checkoutDate) CheckoutDate = checkoutDate.Value;
        if (numberOfRooms.HasValue && NumberOfRooms != numberOfRooms) NumberOfRooms = numberOfRooms.Value;
        if (numberOfAdults.HasValue && NumberOfAdults != numberOfAdults) NumberOfAdults = numberOfAdults.Value;
        if (numberOfChildren.HasValue && NumberOfChildren != numberOfChildren) NumberOfChildren = numberOfChildren.Value;
        if (bookingstatusId.HasValue && bookingstatusId.Value != DefaultIdType.Empty && !BookingstatusId.Equals(bookingstatusId.Value)) BookingstatusId = bookingstatusId.Value;
        if (amount.HasValue && Amount != amount) Amount = amount.Value;
        if (notes is not null && Notes?.Equals(notes) is not true) Notes = notes;
        if (bookingMaterialised.HasValue && BookingMaterialised != bookingMaterialised) BookingMaterialised = bookingMaterialised.Value;
        if (customerId.HasValue && customerId.Value != DefaultIdType.Empty && !CustomerId.Equals(customerId.Value)) CustomerId = customerId.Value;
        if (travelagentId.HasValue && travelagentId.Value != DefaultIdType.Empty && !TravelagentId.Equals(travelagentId.Value)) TravelagentId = travelagentId.Value;
        if (folioId.HasValue && folioId.Value != DefaultIdType.Empty && !FolioId.Equals(folioId.Value)) FolioId = folioId.Value;
        return this;
    }
}