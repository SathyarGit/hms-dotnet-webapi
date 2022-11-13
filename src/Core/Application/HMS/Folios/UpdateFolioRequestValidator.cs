namespace FSH.WebApi.Application.HMS.Folios;

public class UpdateFolioRequestValidator : CustomValidator<UpdateFolioRequest>
{
    public UpdateFolioRequestValidator(IReadRepository<Folio> folioRepo, IReadRepository<Booking> bookingRepo, IReadRepository<Foliotype> foliotypeRepo, IStringLocalizer<UpdateFolioRequestValidator> T)
    {
        RuleFor(p => p.BookingId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await bookingRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Booking {0} Not Found.", id]);

        RuleFor(p => p.FoliotypeId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await foliotypeRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Foliotype {0} Not Found.", id]);
    }
}