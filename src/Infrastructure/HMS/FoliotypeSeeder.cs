using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class FoliotypeSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<FoliotypeSeeder> _logger;

    public FoliotypeSeeder(ISerializerService serializerService, ILogger<FoliotypeSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Foliotypes.Any())
        {
            _logger.LogInformation("Started to Seed Foliotypes.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string foliotypeData = await File.ReadAllTextAsync(path + "/HMS/foliotypes.json", cancellationToken);
            var foliotypes = _serializerService.Deserialize<List<Foliotype>>(foliotypeData);

            if (foliotypes != null)
            {
                foreach (var foliotype in foliotypes)
                {
                    await _db.Foliotypes.AddAsync(foliotype, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Foliotypes.");
        }
    }
}