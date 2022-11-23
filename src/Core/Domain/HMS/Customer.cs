namespace FSH.WebApi.Domain.HMS;

public class Customer : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string AddressLine1 { get; private set; }
    public string AddressLine2 { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string Pincode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Notes { get; private set; }
    public string? ImagePath { get; private set; }
    public DefaultIdType? CustomerclassificationId { get; private set; }

    public virtual Customerclassification Customerclassification { get; set; } = default!;
    public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    public Customer(string name, string? addressLine1, string? addressLine2, string? city, string? country, string? pincode, string? phoneNumber, string? email, string? notes, string? imagePath, DefaultIdType? customerclassificationId)
    {
        Name = name;
        AddressLine1 = addressLine1 ?? string.Empty;
        AddressLine2 = addressLine2 ?? string.Empty;
        City = city ?? string.Empty;
        Country = country ?? string.Empty;
        Pincode = pincode ?? string.Empty;
        PhoneNumber = phoneNumber ?? string.Empty;
        Email = email ?? string.Empty;
        Notes = notes ?? string.Empty;
        ImagePath = imagePath ?? string.Empty;
        CustomerclassificationId = customerclassificationId;
    }

    public Customer Update(string name, string? addressLine1, string? addressLine2, string? city, string? country, string? pincode, string? phoneNumber, string? email, string? notes, string? imagePath, DefaultIdType? customerclassificationId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (addressLine1 is not null && AddressLine1?.Equals(addressLine1) is not true) AddressLine1 = addressLine1;
        if (addressLine2 is not null && AddressLine2?.Equals(addressLine2) is not true) AddressLine2 = addressLine2;
        if (city is not null && City?.Equals(city) is not true) City = city;
        if (country is not null && Country?.Equals(country) is not true) Country = country;
        if (pincode is not null && Pincode?.Equals(pincode) is not true) Pincode = pincode;
        if (phoneNumber is not null && PhoneNumber?.Equals(phoneNumber) is not true) PhoneNumber = phoneNumber;
        if (email is not null && Email?.Equals(email) is not true) Email = email;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        if (customerclassificationId.HasValue && customerclassificationId.Value != DefaultIdType.Empty && !CustomerclassificationId.Equals(customerclassificationId.Value)) CustomerclassificationId = customerclassificationId.Value;
        return this;
    }

    public Customer ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }
}