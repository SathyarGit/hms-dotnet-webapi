using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class RoomstatusSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<RoomstatusSeeder> _logger;

    public RoomstatusSeeder(ISerializerService serializerService, ILogger<RoomstatusSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Roomstatuses.Any())
        {
            _logger.LogInformation("Started to Seed Roomstatuses.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string roomstatusData = await File.ReadAllTextAsync(path + "/HMS/roomstatuses.json", cancellationToken);
            var roomstatuses = _serializerService.Deserialize<List<Roomstatus>>(roomstatusData);

            if (roomstatuses != null)
            {
                foreach (var roomstatus in roomstatuses)
                {
                    await _db.Roomstatuses.AddAsync(roomstatus, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Roomstatuses.");
        }
    }
}