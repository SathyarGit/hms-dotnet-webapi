namespace FSH.WebApi.Application.HMS.Folios;

public class CreateFolioRequestValidator : CustomValidator<CreateFolioRequest>
{
    public CreateFolioRequestValidator(IReadRepository<Folio> folioRepo, IReadRepository<Booking> bookingRepo, IReadRepository<Foliotype> foliotypeRepo, IStringLocalizer<CreateFolioRequestValidator> T)
    {
        RuleFor(p => p.BookingId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await bookingRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Booking {0} Not Found.", id]);

        RuleFor(p => p.FoliotypeId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await foliotypeRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Booking {0} Not Found.", id]);
    }
}