using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class TransactiontypeSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<TransactiontypeSeeder> _logger;

    public TransactiontypeSeeder(ISerializerService serializerService, ILogger<TransactiontypeSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Transactiontypes.Any())
        {
            _logger.LogInformation("Started to Seed Transactiontypes.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string transactiontypeData = await File.ReadAllTextAsync(path + "/HMS/transactiontypes.json", cancellationToken);
            var transactiontypes = _serializerService.Deserialize<List<Transactiontype>>(transactiontypeData);

            if (transactiontypes != null)
            {
                foreach (var transactiontype in transactiontypes)
                {
                    await _db.Transactiontypes.AddAsync(transactiontype, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Transactiontypes.");
        }
    }
}