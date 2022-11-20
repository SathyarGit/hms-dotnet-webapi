using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class BookingstatusSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<BookingstatusSeeder> _logger;

    public BookingstatusSeeder(ISerializerService serializerService, ILogger<BookingstatusSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Bookingstatuses.Any())
        {
            _logger.LogInformation("Started to Seed Bookingstatuses.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string bookingstatusData = await File.ReadAllTextAsync(path + "/HMS/bookingstatuses.json", cancellationToken);
            var bookingstatuses = _serializerService.Deserialize<List<Bookingstatus>>(bookingstatusData);

            if (bookingstatuses != null)
            {
                foreach (var bookingstatus in bookingstatuses)
                {
                    await _db.Bookingstatuses.AddAsync(bookingstatus, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Bookingstatuses.");
        }
    }
}