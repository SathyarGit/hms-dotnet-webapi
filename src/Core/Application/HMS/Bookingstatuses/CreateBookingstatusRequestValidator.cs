namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class CreateBookingstatusRequestValidator : CustomValidator<CreateBookingstatusRequest>
{
    public CreateBookingstatusRequestValidator(IReadRepository<Bookingstatus> bookingstatusRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateBookingstatusRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await bookingstatusRepo.GetBySpecAsync(new BookingstatusByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Bookingstatus {0} already Exists.", name]);

    }
}