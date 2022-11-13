using Finbuckle.MultiTenant.EntityFrameworkCore;
using FSH.WebApi.Domain.HMS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.WebApi.Infrastructure.Persistence.Configuration;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable<Department>("Department", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(d => d.Name)
                .HasMaxLength(128);
    }
}

public class FloorConfig : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.ToTable<Floor>("Floor", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(f => f.Name)
                .HasMaxLength(128);

    }
}

public class RoomConfig : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable<Room>("Room", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Notes)
                .HasMaxLength(512);

        builder
            .Property(r => r.MaintenanceNotes)
                .HasMaxLength(512);
    }
}

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable<Employee>("Employee", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Notes)
                .HasMaxLength(512);
    }
}

public class VendorConfig : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable<Vendor>("Vendor", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Notes)
                .HasMaxLength(512);
    }
}

public class TransactiontypeConfig : IEntityTypeConfiguration<Transactiontype>
{
    public void Configure(EntityTypeBuilder<Transactiontype> builder)
    {
        builder.ToTable<Transactiontype>("Transactiontype", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
    }
}

public class TransactionstatusConfig : IEntityTypeConfiguration<Transactionstatus>
{
    public void Configure(EntityTypeBuilder<Transactionstatus> builder)
    {
        builder.ToTable<Transactionstatus>("Transactionstatus", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
    }
}

public class RoomtypeConfig : IEntityTypeConfiguration<Roomtype>
{
    public void Configure(EntityTypeBuilder<Roomtype> builder)
    {
        builder.ToTable<Roomtype>("Roomtype", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
    }
}

public class RoomstatusConfig : IEntityTypeConfiguration<Roomstatus>
{
    public void Configure(EntityTypeBuilder<Roomstatus> builder)
    {
        builder.ToTable<Roomstatus>("Roomstatus", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
    }
}

public class RoomsbookedConfig : IEntityTypeConfiguration<Roomsbooked>
{
    public void Configure(EntityTypeBuilder<Roomsbooked> builder)
    {
        builder.ToTable<Roomsbooked>("Roomsbooked", "HMS");
        builder.IsMultiTenant();
    }
}

public class PurchaseConfig : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable<Purchase>("Purchase", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Description)
                .HasMaxLength(128);
        builder.Property(r => r.BillsOrInvoiceNumber)
                .HasMaxLength(64);
    }
}

public class PaymentmodeConfig : IEntityTypeConfiguration<Paymentmode>
{
    public void Configure(EntityTypeBuilder<Paymentmode> builder)
    {
        builder.ToTable<Paymentmode>("Paymentmode", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
    }
}

public class FoliotypeConfig : IEntityTypeConfiguration<Foliotype>
{
    public void Configure(EntityTypeBuilder<Foliotype> builder)
    {
        builder.ToTable<Foliotype>("Foliotype", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
    }
}

public class FolioConfig : IEntityTypeConfiguration<Folio>
{
    public void Configure(EntityTypeBuilder<Folio> builder)
    {
        builder.ToTable<Folio>("Folio", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Description)
                .HasMaxLength(128);
    }
}

public class ExpensecategoryConfig : IEntityTypeConfiguration<Expensecategory>
{
    public void Configure(EntityTypeBuilder<Expensecategory> builder)
    {
        builder.ToTable<Expensecategory>("Expensecategory", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
    }
}

public class CustomerclassificationConfig : IEntityTypeConfiguration<Customerclassification>
{
    public void Configure(EntityTypeBuilder<Customerclassification> builder)
    {
        builder.ToTable<Customerclassification>("Customerclassification", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(64);
        builder
            .Property(r => r.Description)
                .HasMaxLength(128);
    }
}

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable<Customer>("Customer", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(128);
        builder
            .Property(r => r.AddressLine1)
                .HasMaxLength(128);
        builder
            .Property(r => r.AddressLine2)
                .HasMaxLength(128);
        builder
            .Property(r => r.City)
                .HasMaxLength(32);
        builder
            .Property(r => r.Country)
                .HasMaxLength(32);
        builder
            .Property(r => r.Pincode)
                .HasMaxLength(32);
        builder
            .Property(r => r.PhoneNumber)
                .HasMaxLength(32);
        builder
            .Property(r => r.Email)
                .HasMaxLength(64);
        builder
            .Property(r => r.Notes)
                .HasMaxLength(512);
    }
}

public class ChargeConfig : IEntityTypeConfiguration<Charge>
{
    public void Configure(EntityTypeBuilder<Charge> builder)
    {
        builder.ToTable<Charge>("Charge", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Description)
                .HasMaxLength(128);
    }
}

public class BookingstatusConfig : IEntityTypeConfiguration<Bookingstatus>
{
    public void Configure(EntityTypeBuilder<Bookingstatus> builder)
    {
        builder.ToTable<Bookingstatus>("Bookingstatus", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Name)
                .HasMaxLength(32);
        builder
            .Property(r => r.Description)
                .HasMaxLength(128);
    }
}

public class BookingConfig : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable<Booking>("Booking", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Notes)
                .HasMaxLength(256);
    }
}

public class AccountentryConfig : IEntityTypeConfiguration<Accountentry>
{
    public void Configure(EntityTypeBuilder<Accountentry> builder)
    {
        builder.ToTable<Accountentry>("Accountentry", "HMS");
        builder.IsMultiTenant();

        builder
            .Property(r => r.Description)
                .HasMaxLength(128);
    }
}