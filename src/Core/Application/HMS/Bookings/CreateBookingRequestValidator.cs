using FSH.WebApi.Domain.HMS;

namespace FSH.WebApi.Application.HMS.Bookings;

public class CreateBookingRequestValidator : CustomValidator<CreateBookingRequest>
{
    public CreateBookingRequestValidator(IReadRepository<Booking> bookingRepo, IReadRepository<Customer> customerRepo, IReadRepository<Folio> folioRepo, IReadRepository<Travelagent> travelagentRepo, IReadRepository<Bookingstatus> bookingstatusRepo, IStringLocalizer<CreateBookingRequestValidator> T)
    {
        RuleFor(b => b.CheckoutDate)
            .GreaterThan(d => d.CheckinDate);

        RuleFor(p => p.CustomerId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await customerRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Customer {0} Not Found.", id]);

        RuleFor(p => p.FolioId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await folioRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Folio {0} Not Found.", id]);

        RuleFor(p => p.TravelagentId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await travelagentRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Travelagent {0} Not Found.", id]);

        RuleFor(p => p.BookingstatusId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await bookingstatusRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Folio {0} Not Found.", id]);
    }
}