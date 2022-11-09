using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class RoomSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<RoomSeeder> _logger;

    public RoomSeeder(ISerializerService serializerService, ILogger<RoomSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Floors.Any())
        {
            _logger.LogInformation("Started to Seed Floors.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string floorData = await File.ReadAllTextAsync(path + "/HMS/floors.json", cancellationToken);
            var floors = _serializerService.Deserialize<List<Floor>>(floorData);

            if (floors != null)
            {
                foreach (var floor in floors)
                {
                    await _db.Floors.AddAsync(floor, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Floors.");
        }
    }
}