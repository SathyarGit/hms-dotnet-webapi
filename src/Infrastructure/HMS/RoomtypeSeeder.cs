using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class RoomtypeSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<RoomtypeSeeder> _logger;

    public RoomtypeSeeder(ISerializerService serializerService, ILogger<RoomtypeSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Roomtypes.Any())
        {
            _logger.LogInformation("Started to Seed Roomtypes.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string roomtypeData = await File.ReadAllTextAsync(path + "/HMS/roomtypes.json", cancellationToken);
            var roomtypes = _serializerService.Deserialize<List<Roomtype>>(roomtypeData);

            if (roomtypes != null)
            {
                foreach (var roomtype in roomtypes)
                {
                    await _db.Roomtypes.AddAsync(roomtype, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Roomtypes.");
        }
    }
}