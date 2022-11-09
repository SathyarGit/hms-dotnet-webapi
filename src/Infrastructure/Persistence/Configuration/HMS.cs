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