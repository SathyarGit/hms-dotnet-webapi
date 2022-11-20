using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class TransactionstatusSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<TransactionstatusSeeder> _logger;

    public TransactionstatusSeeder(ISerializerService serializerService, ILogger<TransactionstatusSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Transactionstatuses.Any())
        {
            _logger.LogInformation("Started to Seed Transactionstatuses.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string transactionstatusData = await File.ReadAllTextAsync(path + "/HMS/transactionstatuses.json", cancellationToken);
            var transactionstatuses = _serializerService.Deserialize<List<Transactionstatus>>(transactionstatusData);

            if (transactionstatuses != null)
            {
                foreach (var transactionstatus in transactionstatuses)
                {
                    await _db.Transactionstatuses.AddAsync(transactionstatus, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Transactionstatuses.");
        }
    }
}