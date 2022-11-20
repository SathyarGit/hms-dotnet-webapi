using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class ExpensecategorySeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<ExpensecategorySeeder> _logger;

    public ExpensecategorySeeder(ISerializerService serializerService, ILogger<ExpensecategorySeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Expensecategories.Any())
        {
            _logger.LogInformation("Started to Seed Expensecategories.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string expensecategoryData = await File.ReadAllTextAsync(path + "/HMS/expensecategories.json", cancellationToken);
            var expensecategories = _serializerService.Deserialize<List<Expensecategory>>(expensecategoryData);

            if (expensecategories != null)
            {
                foreach (var expensecategory in expensecategories)
                {
                    await _db.Expensecategories.AddAsync(expensecategory, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Expensecategories.");
        }
    }
}