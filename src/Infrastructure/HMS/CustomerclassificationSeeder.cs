using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class CustomerclassificationSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<CustomerclassificationSeeder> _logger;

    public CustomerclassificationSeeder(ISerializerService serializerService, ILogger<CustomerclassificationSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Customerclassifications.Any())
        {
            _logger.LogInformation("Started to Seed Customerclassificationss.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string customerclassificationsData = await File.ReadAllTextAsync(path + "/HMS/customerclassifications.json", cancellationToken);
            var customerclassifications = _serializerService.Deserialize<List<Customerclassification>>(customerclassificationsData);

            if (customerclassifications != null)
            {
                foreach (var customerclassification in customerclassifications)
                {
                    await _db.Customerclassifications.AddAsync(customerclassification, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Customerclassificationss.");
        }
    }
}