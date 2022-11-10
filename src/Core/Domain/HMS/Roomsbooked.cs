namespace FSH.WebApi.Domain.HMS;

public class Roomsbooked : AuditableEntity, IAggregateRoot
{
    public int? RoomRate { get; private set; }
    public DefaultIdType? RoomId { get; private set; }
    public DefaultIdType? BookingId { get; private set; }

    public virtual Booking Booking { get; set; } = default!;
    public virtual Room Room { get; set; } = default!;

    public Roomsbooked(int? roomRate, DefaultIdType? roomId, DefaultIdType? bookingId)
    {
        RoomRate = roomRate;
        BookingId = bookingId;
        BookingId = bookingId;
    }

    public Roomsbooked Update(int? roomRate, DefaultIdType? roomId, DefaultIdType? bookingId)
    {
        if (roomRate.HasValue && RoomRate != roomRate) RoomRate = roomRate.Value;
        if (roomId.HasValue && roomId.Value != DefaultIdType.Empty && !RoomId.Equals(roomId.Value)) RoomId = roomId.Value;
        if (bookingId.HasValue && bookingId.Value != DefaultIdType.Empty && !BookingId.Equals(bookingId.Value)) BookingId = bookingId.Value;
        return this;
    }
}