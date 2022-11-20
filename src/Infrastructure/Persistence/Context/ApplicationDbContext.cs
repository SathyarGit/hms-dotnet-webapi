using Finbuckle.MultiTenant;
using FSH.WebApi.Application.Common.Events;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.WebApi.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();

    public DbSet<Floor> Floors => Set<Floor>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Accountentry> Accountentries => Set<Accountentry>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Bookingstatus> Bookingstatuses => Set<Bookingstatus>();
    public DbSet<Charge> Charges => Set<Charge>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Customerclassification> Customerclassifications => Set<Customerclassification>();
    public DbSet<Expensecategory> Expensecategories => Set<Expensecategory>();
    public DbSet<Folio> Folios => Set<Folio>();
    public DbSet<Foliotype> Foliotypes => Set<Foliotype>();
    public DbSet<Paymentmode> Paymentmodes => Set<Paymentmode>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<Roomsbooked> Roomsbookeds => Set<Roomsbooked>();
    public DbSet<Roomstatus> Roomstatuses => Set<Roomstatus>();
    public DbSet<Roomtype> Roomtypes => Set<Roomtype>();
    public DbSet<Transactionstatus> Transactionstatuses => Set<Transactionstatus>();
    public DbSet<Transactiontype> Transactiontypes => Set<Transactiontype>();
    public DbSet<Travelagent> Travelagents => Set<Travelagent>();
    public DbSet<Vendor> Vendors => Set<Vendor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}