namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class UpdateBookingstatusRequestValidator : CustomValidator<UpdateBookingstatusRequest>
{
    public UpdateBookingstatusRequestValidator(IReadRepository<Bookingstatus> bookingstatusRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateBookingstatusRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (bookingstatus, name, ct) =>
                    await bookingstatusRepo.GetBySpecAsync(new BookingstatusByNameSpec(name), ct)
                        is not Bookingstatus existingBookingstatus || existingBookingstatus.Id == bookingstatus.Id)
                .WithMessage((_, name) => T["Bookingstatus {0} already Exists.", name]);
    }
}