using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class DepartmentSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<DepartmentSeeder> _logger;

    public DepartmentSeeder(ISerializerService serializerService, ILogger<DepartmentSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Departments.Any())
        {
            _logger.LogInformation("Started to Seed Departments.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string departmentData = await File.ReadAllTextAsync(path + "/HMS/departments.json", cancellationToken);
            var departments = _serializerService.Deserialize<List<Department>>(departmentData);

            if (departments != null)
            {
                foreach (var department in departments)
                {
                    await _db.Departments.AddAsync(department, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Departments.");
        }
    }
}