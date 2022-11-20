using System.Reflection;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.HMS;
using FSH.WebApi.Infrastructure.Persistence.Context;
using FSH.WebApi.Infrastructure.Persistence.Initialization;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.HMS;

public class PaymentmodeSeeder : ICustomSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<PaymentmodeSeeder> _logger;

    public PaymentmodeSeeder(ISerializerService serializerService, ILogger<PaymentmodeSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {

        string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!_db.Paymentmodes.Any())
        {
            _logger.LogInformation("Started to Seed Paymentmodes.");

            // Here you can use your own logic to populate the database.
            // As an example, I am using a JSON file to populate the database.
            string paymentmodeData = await File.ReadAllTextAsync(path + "/HMS/paymentmodes.json", cancellationToken);
            var paymentmodes = _serializerService.Deserialize<List<Paymentmode>>(paymentmodeData);

            if (paymentmodes != null)
            {
                foreach (var paymentmode in paymentmodes)
                {
                    await _db.Paymentmodes.AddAsync(paymentmode, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Seeded Paymentmodes.");
        }
    }
}